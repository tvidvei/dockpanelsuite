using System.ComponentModel;
using System.Reflection;

namespace Utilities
{

    public class ExpandableObjectWithDynamicDefaultsConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            BackingFieldNamesAttribute? backingFieldNamesAttr =
                value.GetType().GetCustomAttribute<BackingFieldNamesAttribute>() ??
                value.GetType().Assembly.GetCustomAttribute<BackingFieldNamesAttribute>();
            var pdc = TypeDescriptor.GetProperties(value, attributes);
            var pdA = new PropertyDescriptor[pdc.Count];
            for (int i = 0; i < pdc.Count; i++) pdA[i] = new PropertyWithDynamicDefaultsDescriptor(pdc[i], backingFieldNamesAttr?.GetBackingFieldName);
            return new PropertyDescriptorCollection(pdA, readOnly: true);
        }
    }


    public delegate string GetBackingFieldNameFunc(string propertyName);

    /// <summary>
    /// Provide a function to derive the backing field name from the property name
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Class | AttributeTargets.Assembly)]
    public class BackingFieldNamesAttribute : Attribute
    {

        /// <summary>
        /// function to derive the backing field name from the property name
        /// </summary>
        /// If no function is given, backingFields are assumed to be the same as the property name with a lower case first letter
        public GetBackingFieldNameFunc GetBackingFieldName { get; set; } = (s) => s;

        public BackingFieldNamesAttribute() { }

        public BackingFieldNamesAttribute(GetBackingFieldNameFunc getBackingFieldName)
        {
            GetBackingFieldName = getBackingFieldName;
        }

    }


    [AttributeUsage(AttributeTargets.Property)]
    public class BackingFieldAttribute : Attribute
    {

        /// <summary>
        /// Name of field holding the assigned value
        /// </summary>
        /// If AssignedValue is not given, it is assumed to be same as the property name with a lower case first letter 
        public string? BackingFieldName { get; set; }

        public BackingFieldAttribute() { }

        public BackingFieldAttribute(string? backingFieldName = null)
        {
            BackingFieldName = backingFieldName;
        }
    }


    /// <summary>
    /// PropertyDescriptor with handling of dynamic default value given by a property
    /// </summary>
    /// The property must be set up with a backing field holding the assigned value and a Get-method of the following form:
    /// Get => assignedValue == default(typeof(T)) ? defaultValueProperty : assignedValue;  where T is the type of the property
    /// The default value is given by a property identified by either adding "Default" to the property name, or a name given
    /// in the DefaultValuePropertyAttribute. The given value has
    public class PropertyWithDynamicDefaultsDescriptor : PropertyDescriptor
    {

        private PropertyDescriptor pd;

        public bool HasBackingField => BackingField != null;

        public FieldInfo? BackingField = null;
        public object? TypeDefaultValue;

        public PropertyWithDynamicDefaultsDescriptor(PropertyDescriptor propertyDescription, GetBackingFieldNameFunc? getBackingFieldName = null) : base(propertyDescription)
        {
            pd = propertyDescription;
            string backingFieldName = getBackingFieldName != null ? getBackingFieldName(Name) : 
                Name[0].ToString().ToLower() + Name.Substring(1);  // Default name for assigned value field

            var ddAttrs = pd.Attributes.OfType<BackingFieldAttribute>();
            if (ddAttrs.Count() > 0)
            {
                var ddAttr = ddAttrs.First();
                if (ddAttr.BackingFieldName != null) backingFieldName = ddAttr.BackingFieldName;
            }

            TypeDefaultValue = Activator.CreateInstance(PropertyType);
            BackingField = ComponentType.GetField(backingFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override Type ComponentType => pd.ComponentType;

        public override bool IsReadOnly => pd.IsReadOnly;

        public override Type PropertyType => pd.PropertyType;

        public override bool CanResetValue(object component)
        {
            return pd.CanResetValue(component);
        }

        public override object? GetValue(object? component)
        {
            return pd.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            if (HasBackingField) pd.SetValue(component, TypeDefaultValue);
            else pd.ResetValue(component);
        }

        public override void SetValue(object? component, object? value)
        {
            pd.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return
                HasBackingField ? !string.IsNullOrEmpty(Converter.ConvertToString(BackingField!.GetValue(component)))
                                    : pd.ShouldSerializeValue(component);
        }

    }



}
