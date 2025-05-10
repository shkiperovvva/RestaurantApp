using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace restaurant2
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields(
                NewNameTextBox.Text,
                NewLastnameTextBox.Text,
                NewEmailTextBox.Text,
                NewPasswordBox.Password,
                RepeatPasswordBox.Password,
                out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            string name = NewNameTextBox.Text.Trim();
            string lastname = NewLastnameTextBox.Text.Trim();
            string email = NewEmailTextBox.Text.Trim();
            string password = NewPasswordBox.Password;

            try
            {
                // Удаляем using, так как контекст будет управляться внутри InsertClientData
                InsertClientData(name, lastname, email, password);

                MessageBox.Show("Регистрация прошла успешно!");
                Autorization autorization = new Autorization();
                autorization.Show();
                this.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public bool ValidateFields(string name, string lastname, string email,
                                  string password, string repeatPassword, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
                errorMessage = "Имя не может быть пустым.";
            else if (string.IsNullOrWhiteSpace(lastname))
                errorMessage = "Фамилия не может быть пустой.";
            else if (string.IsNullOrWhiteSpace(email))
                errorMessage = "Email не может быть пустым.";
            else if (string.IsNullOrWhiteSpace(password))
                errorMessage = "Пароль не может быть пустым.";
            else if (password != repeatPassword)
                errorMessage = "Пароли не совпадают.";

            return string.IsNullOrEmpty(errorMessage);
        }

        private void InsertClientData(string name, string lastname, string email, string password)
        {
            using (var context = RestaurantContext.GetContext())
            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "CALL restaurant.insert_client(@p_name_client, @p_lastname_client, @p_email, @p_password)";

                    cmd.Parameters.Add(new NpgsqlParameter("p_name_client", name));
                    cmd.Parameters.Add(new NpgsqlParameter("p_lastname_client", lastname));
                    cmd.Parameters.Add(new NpgsqlParameter("p_email", email));
                    cmd.Parameters.Add(new NpgsqlParameter("p_password", password));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AutorizationHyperLink_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }
    }
}