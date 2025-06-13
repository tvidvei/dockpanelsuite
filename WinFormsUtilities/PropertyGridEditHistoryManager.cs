using System.ComponentModel;
using Utilities;

namespace WinFormsUtilities
{
    public class PropertyGridEditHistoryManager : EditHistoryManager<GridItem, object?>
    {

        private PropertyGrid PropertyGrid { get; set; }

        public override bool AreEqualValues(GridItem item, object? value1, object? value2)
        {
            var converter = item.PropertyDescriptor?.Converter;
            if (converter != null) return string.Equals(converter.ConvertToString(value1), converter.ConvertToString(value2));
            return String.Equals(value1, value2);
        }

        public override void SetValue(GridItem item, object? value)
        {
            item.PropertyDescriptor!.SetValue(item.Parent?.Value ?? PropertyGrid.SelectedObject, value);
            item.Select();
            PropertyGrid.Refresh();
        }

        public PropertyGridEditHistoryManager(PropertyGrid propertyGrid) : base()
        {
            PropertyGrid = propertyGrid;
        }

    }




}
