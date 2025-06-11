using System.ComponentModel;
using Utilities;

namespace WinFormsUtilities
{
    public class PropertyGridEditHistoryManager : EditHistoryManager<GridItem, object>
    {

        public Component Component { get; private set; }

        public override bool AreEqualValues(GridItem item, object? value1, object? value2)
        {
            var converter = item.PropertyDescriptor?.Converter;
            if (converter != null) return String.Equals(converter.ConvertToString(value1), converter.ConvertToString(value2));
            return String.Equals(value1, value2);
        }

        public override void SetValue(GridItem item, object? value)
        {
            var oldValue = item.Value;  
            item.PropertyDescriptor!.SetValue(Component, value);
            //return !AreEqualValues(item, oldValue, value);
        }

        public PropertyGridEditHistoryManager(Component component) : base() { 
            Component = component;
        }

    }

}
