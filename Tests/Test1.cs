using Microsoft.VisualStudio.TestTools.UnitTesting;
using restaurant2;
using restaurant2.Tests.Attributes;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace restaurant2.Tests
{
    
    [TestClass]
    public class ReportGenerationWindowTests
    {
        private static Application _app;
        private ReportGenerationWindow _reportGenerationWindow;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            if (Application.Current == null)
            {
                Thread thread = new Thread(() =>
                {
                    _app = new Application();
                    _app.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                Thread.Sleep(100);
            }
        }

        [TestInitialize]
        public void Setup()
        {

            _reportGenerationWindow = (ReportGenerationWindow)Application.Current.Dispatcher.Invoke((System.Func<ReportGenerationWindow>)(() =>
            {
                ReportGenerationWindow window = new ReportGenerationWindow();
                return window;
            }));
        }

        [TestMethod]
        public void CreateSalesReport()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Отчет_по_продажам_по_месяцам.pdf");
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Не удалось удалить файл: {e.Message}");
                    Assert.Fail($"Не удалось удалить файл: {e.Message}");
                }
            }

            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _reportGenerationWindow.SalesReportButton_Click(null, null);
                });

                Assert.IsTrue(File.Exists(filePath), "Файл отчета не был создан.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка в тесте: {e.Message}");
                Assert.Fail($"Произошла ошибка в тесте: {e.Message}");
            }
        }

        [TestMethod]
        public void CreateEmployeeSalesReport()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Отчет_по_персоналу.pdf");
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Не удалось удалить файл: {e.Message}");
                    Assert.Fail($"Не удалось удалить файл: {e.Message}");
                }
            }

            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _reportGenerationWindow.EmployeeSalesReportButton_Click(null, null);
                });

                Assert.IsTrue(File.Exists(filePath), "Файл отчета по сотрудникам не был создан.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка в тесте: {e.Message}");
                Assert.Fail($"Произошла ошибка в тесте: {e.Message}");
            }
        }

        [TestMethod]
        public void CreateProductSalesReport()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Отчет_продаваемости_товаров.pdf");
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Не удалось удалить файл: {e.Message}");
                    Assert.Fail($"Не удалось удалить файл: {e.Message}");
                }
            }

            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _reportGenerationWindow.ProductSalesButton_Click(null, null);
                });

                Assert.IsTrue(File.Exists(filePath), "Файл отчета по продаваемости товаров не был создан.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка в тесте: {e.Message}");
                Assert.Fail($"Произошла ошибка в тесте: {e.Message}");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_reportGenerationWindow != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _reportGenerationWindow.Close();
                });
            }
        }
    }
    [TestClass]
    public class RegistrationTests
    {
        private Registration _registration;

        [TestInitialize]
        public void Setup()
        {
            _registration = new Registration();
        }

        [WpfTestMethod]
        public void ValidateFields_NotEmpty()
        {
            // Данные
            string name = "Иван";
            string lastname = "Иванов";
            string email = "ivan@example.com";
            string password = "password123";
            string repeatPassword = "password123";

            // Проверка на заполненность всех полей
            bool result = _registration.ValidateFields(name, lastname, email, password, repeatPassword, out string errorMessage);

            // Результат
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, errorMessage);
        }

        [WpfTestMethod]
        public void ValidateFields_EmptyName()
        {
            // Данные
            string name = "";
            string lastname = "Иванов";
            string email = "ivan@example.com";
            string password = "password123";
            string repeatPassword = "password123";

            // Проверка на заполнение поля имя
            bool result = _registration.ValidateFields(name, lastname, email, password, repeatPassword, out string errorMessage);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Имя не может быть пустым.", errorMessage);
        }

        [WpfTestMethod]
        public void ValidateFields_EmptyLastname()
        {
            // Данные
            string name = "Иван";
            string lastname = " ";
            string email = "ivan@example.com";
            string password = "password123";
            string repeatPassword = "password123";

            // Проверка на заполнение данных поля фамилия
            bool result = _registration.ValidateFields(name, lastname, email, password, repeatPassword, out string errorMessage);

            // Результат
            Assert.IsFalse(result);
            Assert.AreEqual("Фамилия не может быть пустой.", errorMessage);
        }

        [WpfTestMethod]
        public void ValidateFields_EmptyEmail()
        {
            // Данные
            string name = "Иван";
            string lastname = "Иванов";
            string email = "";
            string password = "password123";
            string repeatPassword = "password123";

            // Проверка на заполнение поля электронной почты
            bool result = _registration.ValidateFields(name, lastname, email, password, repeatPassword, out string errorMessage);

            // Результат
            Assert.IsFalse(result);
            Assert.AreEqual("Email не может быть пустым.", errorMessage);
        }

        [WpfTestMethod]
        public void ValidateFields_EmptyPassword()
        {
            // Данные
            string name = "Иван";
            string lastname = "Иванов";
            string email = "ivan@example.com";
            string password = "";
            string repeatPassword = "";

            // Проверка на заполнение полей пароля
            bool result = _registration.ValidateFields(name, lastname, email, password, repeatPassword, out string errorMessage);

            // Результат
            Assert.IsFalse(result);
            Assert.AreEqual("Пароль не может быть пустым.", errorMessage);
        }

        [WpfTestMethod]
        public void ValidateFields_PasswordsDoNotMatch()
        {
            // Данные для провеки
            string name = "Иван";
            string lastname = "Иванов";
            string email = "ivan@example.com";
            string password = "password123";
            string repeatPassword = "password321";

            // Проверка на совпадение паролей
            bool result = _registration.ValidateFields(name, lastname, email, password, repeatPassword, out string errorMessage);

            // Результат
            Assert.IsFalse(result);
            Assert.AreEqual("Пароли не совпадают.", errorMessage);
        }
    }

    [TestClass]
    public class EditStatusWindowTests
    {
        private EditStatusWindow _window;

        [TestInitialize]
        public void Setup()
        {
            // Создаем окно с текущим статусом "начат"
            _window = null;
            var resetEvent = new ManualResetEvent(false);

            var thread = new Thread(() =>
            {
                _window = new EditStatusWindow("начат");
                resetEvent.Set();
                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            resetEvent.WaitOne();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_window != null)
            {
                _window.Dispatcher.Invoke(() =>
                {
                    _window.Close();
                    System.Windows.Threading.Dispatcher.ExitAllFrames();
                });
            }
        }
        [WpfTestMethod]
        public void SaveButton_Click_WithSelectedStatus()
        {
            _window.Dispatcher.Invoke(() =>
            {
                // Устанавливаем нужный статус
                _window.StatusComboBox.SelectedItem = "готов";

                // Открываем окно для нажатия на кнопку сохранения
                bool? dialogResult = _window.ShowDialog();

                // После закрытия окна проверяем результат
                Assert.AreEqual("готов", _window.SelectedStatus);
                Assert.IsTrue(dialogResult == true);
            });
        }
    }
}
