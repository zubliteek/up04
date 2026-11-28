using HelpDesk.Data;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HelpDesk.Views
{
    public partial class TicketCreateWindow : Window
    {
        public TicketCreateWindow()
        {
            InitializeComponent();

            try
            {
                LoadCategories();
                LoadPriorities();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Не удалось загрузить справочники:\n" + ex.Message, "Ошибка базы данных",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadCategories()
        {
            CategoryComboBox.Items.Clear();

            string sql = "SELECT Id, Name FROM Categories ORDER BY Name";

            using (SqlConnection connection = Database.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = reader["Name"].ToString();
                        item.Tag = Convert.ToInt32(reader["Id"]);

                        CategoryComboBox.Items.Add(item);
                    }
                }
            }
        }

        private void LoadPriorities()
        {
            PriorityComboBox.Items.Clear();

            string sql = "SELECT Id, Name FROM Priorities ORDER BY SortOrder";

            using (SqlConnection connection = Database.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = reader["Name"].ToString();
                        item.Tag = Convert.ToInt32(reader["Id"]);

                        PriorityComboBox.Items.Add(item);
                    }
                }
            }

            PriorityComboBox.SelectedItem = PriorityComboBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(i => (string)i.Content == "Средний");
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

            if (PriorityComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите приоритет заявки.",
                    "Проверка данных",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            MessageBox.Show(
                "Данные заявки заполнены корректно.\n" +
                "На следующих занятиях заявка будет сохраняться в MS SQL Server.",
                "HelpDesk",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
