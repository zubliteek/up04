using HelpDesk.Helpers;
using HelpDesk.Models;
using System.Windows;

namespace HelpDesk.Views
{
    public partial class TicketEditWindow : Window
    {
        private readonly Ticket ticket;

        public TicketEditWindow(Ticket ticket)
        {
            InitializeComponent();

            this.ticket = ticket;

            TicketIdTextBlock.Text = "Заявка №: " + ticket.Id;
            DescriptionTextBox.Text = ticket.Description;

            ComboBoxHelper.SelectByText(CategoryComboBox, ticket.Category);
            ComboBoxHelper.SelectByText(PriorityComboBox, ticket.Priority);
            ComboBoxHelper.SelectByText(StatusComboBox, ticket.Status);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите категорию заявки.",
                    "Проверка данных",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show(
                    "Введите описание проблемы.",
                    "Проверка данных",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (PriorityComboBox.SelectedItem == null || StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите приоритет и статус заявки.",
                    "Проверка данных",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            ticket.Category = ComboBoxHelper.GetSelectedText(CategoryComboBox);
            ticket.Description = DescriptionTextBox.Text.Trim();
            ticket.Priority = ComboBoxHelper.GetSelectedText(PriorityComboBox);
            ticket.Status = ComboBoxHelper.GetSelectedText(StatusComboBox);

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
