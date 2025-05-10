using System;
using System.Text.Json;
using System.Windows;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace restaurant2
{
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                {
                    MessageBox.Show("Введите название блюда.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(GrammeTextBox.Text))
                {
                    MessageBox.Show("Введите граммовку блюда.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(CategoryTextBox.Text))
                {
                    MessageBox.Show("Введите категорию блюда.");
                    return;
                }

                if (!int.TryParse(PriceTextBox.Text, out int parsedPrice))
                {
                    MessageBox.Show("Введите корректную цену (целое число).");
                    return;
                }

                string name = NameTextBox.Text;
                string about = AboutTextBox.Text;
                int price = parsedPrice;
                string gramme = GrammeTextBox.Text;
                string category = CategoryTextBox.Text;

                // формирование JSON
                var categoryGrammeObject = new
                {
                    gramme = gramme,
                    category = category
                };
                string categoryGrammeJson = JsonSerializer.Serialize(categoryGrammeObject);

                // Создаем новую позицию меню
                var newItem = new Menu
                {
                    name_dish = name,
                    about_dish = about,
                    price = price,
                    category_gramme = categoryGrammeJson
                };

                // Добавляем в базу данных
                using (var context = new RestaurantContext())
                {
                    context.Menu.Add(newItem);
                    context.SaveChanges();
                }

                MessageBox.Show("Позиция успешно добавлена в меню.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка PostgreSQL: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении позиции: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}