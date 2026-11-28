using System.Linq;
using System.Windows.Controls;

namespace HelpDesk.Helpers
{
    public static class ComboBoxHelper
    {
        public static void SelectByText(ComboBox comboBox, string text)
        {
            var item = comboBox.Items
                .OfType<ComboBoxItem>()
                .FirstOrDefault(i => (string)i.Content == text);

            if (item == null)
            {
                item = new ComboBoxItem { Content = text };
                comboBox.Items.Add(item);
            }

            comboBox.SelectedItem = item;
        }

        public static string GetSelectedText(ComboBox comboBox)
        {
            var item = comboBox.SelectedItem as ComboBoxItem;
            return item == null ? null : item.Content as string;
        }
    }
}
