using System.ComponentModel;
using System.Reflection;

namespace Utilities
{

    public class ExpandableObjectWithDynamicDefaultsConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            var pdc = TypeDescriptor.GetProperties(value, attributes);
            var pdA = new PropertyDescriptor[pdc.Count];
            for (int i = 0; i < pdc.Count; i++) pdA[i] = new PropertyWithDynamicDefaultsDescriptor(pdc[i]);
            return new PropertyDescriptorCollection(pdA, readOnly: true);
        }
    }


    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DefaultValuePropertyAttribute : Attribute
    {

        /// <summary>
        /// Name of property to be used as the value
        /// </summary>
        public string? DefaultValuePropertyName { get; set; }

        /// <summary>
        /// Name of field or property holding the assigned value
        /// </summary>
        /// If AssignedValue is not given, it is assumed to be same as the property name with a lower case first letter 
        public string? AssignedValueFieldName { get; set; }

        public DefaultValuePropertyAttribute() { }

        public DefaultValuePropertyAttribute(string? defaultValuePropertyName, string? assignedValueFieldName = null)
        {
            DefaultValuePropertyName = defaultValuePropertyName;
            AssignedValueFieldName = assignedValueFieldName;
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

        public bool HasDynamicDefault => DefaultValueProperty != null;

        public PropertyInfo? DefaultValueProperty = null;
        public FieldInfo? AssignedValueField = null;
        public object? TypeDefaultValue;

        public PropertyWithDynamicDefaultsDescriptor(PropertyDescriptor propertyDescription) : base(propertyDescription)
        {
            pd = propertyDescription;
            string assignedValueName = Name[0].ToString().ToLower() + Name.Substring(1);             // Default name for assigned value field
            string defaultValueName = assignedValueName + "Default";                                 // Default name for default value property

            var ddAttrs = pd.Attributes.OfType<DefaultValuePropertyAttribute>();
            if (ddAttrs.Count() > 0)
            {
                var ddAttr = ddAttrs.First();
                if (ddAttr.AssignedValueFieldName != null) assignedValueName = ddAttr.AssignedValueFieldName;
                if (ddAttr.DefaultValuePropertyName != null) defaultValueName = ddAttr.DefaultValuePropertyName;

            }

            TypeDefaultValue = Activator.CreateInstance(PropertyType);
            DefaultValueProperty = ComponentType.GetProperty(defaultValueName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            AssignedValueField = ComponentType.GetField(assignedValueName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
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
            if (HasDynamicDefault) pd.SetValue(component, TypeDefaultValue);
            else pd.ResetValue(component);
        }

        public override void SetValue(object? component, object? value)
        {
            pd.SetValue(component, value);
        }

        public object? GetDefaultValue(object? component)
        {
            return HasDynamicDefault ? DefaultValueProperty?.GetValue(component) : TypeDefaultValue;  // Todo: Må håndtere defaultverdi fra DefaultValueAttribute, og uten som er TypeDefaultValue
        }


        public override bool ShouldSerializeValue(object component)
        {
            return
                HasDynamicDefault ? !String.IsNullOrEmpty(Converter.ConvertToString(AssignedValueField!.GetValue(component)))
                                    : pd.ShouldSerializeValue(component);
        }

    }



}
