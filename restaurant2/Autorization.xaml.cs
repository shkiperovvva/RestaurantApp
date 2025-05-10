using System;
using System.Windows;
using Npgsql;

namespace restaurant2
{
    public partial class Autorization : Window
    {
        private readonly string ConnectionString = "Host=172.20.7.53;Port=5432;Database=db2992_23;Username=st2992;Password=pwd2992";
        public Autorization()
        {
            InitializeComponent();
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var cmd = new NpgsqlCommand("SELECT restaurant.check_user_credentials(@email, @password)", connection))
                    {
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("password", password);

                        var result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            int userRole = Convert.ToInt32(result);

                            switch (userRole)
                            {
                                case 1:
                                    new MainWindow(email).Show();
                                    break;
                                case 2:
                                    new MainWindowEmployee(email).Show();
                                    break;
                                case 3:
                                    new MainWindowAdmin(email).Show();
                                    break;
                                default:
                                    MessageBox.Show("Неизвестная роль пользователя.");
                                    return;
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный email или пароль.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации: {ex.Message}");
            }
        }

        public void RegisterHyperlink_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}