using System;
using System.Data;
using System.IO;
using System.Windows;
using Npgsql;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Charting;

namespace restaurant2
{
    public partial class ReportGenerationWindow : Window
    {
        private const string ConnectionString = @"Host=172.20.7.53;Port=5432;Database=db2992_23;Username=st2992;Password=pwd2992;SearchPath=restaurant";

        public ReportGenerationWindow()
        {
            InitializeComponent();
        }

        private DataTable GetData_SalesReport()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT formatted_date, total_sales FROM restaurant.sales_report";
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private DataTable GetData_EmployeeSalesReport()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM restaurant.employee_sales_report";
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private DataTable GetData_ProductSalesReport()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM restaurant.dish_sales_report";
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void SalesReportButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "Отчет_по_продажам_по_месяцам.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            try
            {
                DataTable dataTable = GetData_SalesReport();

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XFont titleFont = new XFont("Arial", 16);
                XFont headerFont = new XFont("Arial", 12);
                XFont cellFont = new XFont("Arial", 10);
                XFont footerFont = new XFont("Arial", 8);
                XFont chartTitleFont = new XFont("Arial", 14); 

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    // Заголовок
                    string titleText = "Отчет по продажам по месяцам";
                    XSize titleSize = gfx.MeasureString(titleText, titleFont);
                    gfx.DrawString(titleText, titleFont, XBrushes.Black,
                        new XPoint((page.Width - titleSize.Width) / 2, 40));

                    // Таблица
                    double tableWidth = 300;
                    double startX = (page.Width - tableWidth) / 2;
                    double currentY = 70;
                    double rowHeight = 25;
                    double headerHeight = 30;

                    string[] headers = { "Период", "Сумма продаж" };
                    double[] columnWidths = { 200, 100 };

                    XPen borderPen = new XPen(XColors.Black, 0.5);
                    gfx.DrawRectangle(borderPen, startX, currentY, tableWidth, headerHeight);

                    double verticalLineX = startX;
                    for (int i = 0; i < columnWidths.Length; i++)
                    {
                        verticalLineX += columnWidths[i];
                        gfx.DrawLine(borderPen,
                            verticalLineX, currentY,
                            verticalLineX, currentY + headerHeight);
                    }

                    double textX = startX;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        gfx.DrawString(headers[i], headerFont, XBrushes.Black,
                            new XRect(textX, currentY + 5, columnWidths[i], headerHeight),
                            XStringFormats.Center);
                        textX += columnWidths[i];
                    }
                    currentY += headerHeight;

                    // Данные таблицы
                    foreach (DataRow row in dataTable.Rows)
                    {
                        gfx.DrawRectangle(borderPen, startX, currentY, tableWidth, rowHeight);

                        verticalLineX = startX;
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            verticalLineX += columnWidths[i];
                            gfx.DrawLine(borderPen,
                                verticalLineX, currentY,
                                verticalLineX, currentY + rowHeight);
                        }

                        gfx.DrawString(row["formatted_date"].ToString(), cellFont, XBrushes.Black,
                            new XRect(startX, currentY, columnWidths[0], rowHeight),
                            XStringFormats.Center);

                        gfx.DrawString(Convert.ToDecimal(row["total_sales"]).ToString("N2") + " ₽",
                            cellFont, XBrushes.Black,
                            new XRect(startX + columnWidths[0], currentY, columnWidths[1], rowHeight),
                            XStringFormats.Center);

                        currentY += rowHeight;
                    }

                    // Заголовок перед графиком
                    string chartTitle = "Статистика продаж ресторана по месяцам";
                    XSize chartTitleSize = gfx.MeasureString(chartTitle, chartTitleFont);
                    currentY += 50; // Отступ после таблицы
                    gfx.DrawString(chartTitle, chartTitleFont, XBrushes.Black,
                        new XPoint((page.Width - chartTitleSize.Width) / 2, currentY));
                    currentY += chartTitleSize.Height + 30; // Отступ после заголовка

                    // Диаграмма
                    double chartStartY = currentY;
                    double chartHeight = 200;
                    double chartWidth = 500;
                    double chartStartX = (page.Width - chartWidth) / 2;
                    double barWidth = chartWidth / dataTable.Rows.Count * 0.7;
                    double barSpacing = chartWidth / dataTable.Rows.Count * 0.3;

                    double maxSales = dataTable.AsEnumerable()
                                                .Select(r => Convert.ToDouble(r["total_sales"]))
                                                .DefaultIfEmpty(0)
                                                .Max();

                    // Ось Y
                    gfx.DrawLine(borderPen, chartStartX, chartStartY, chartStartX, chartStartY + chartHeight);
                    // Ось X
                    gfx.DrawLine(borderPen, chartStartX, chartStartY + chartHeight, chartStartX + chartWidth, chartStartY + chartHeight);

                    // Столбцы
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        double sales = Convert.ToDouble(dataTable.Rows[i]["total_sales"]);
                        double barHeight = maxSales > 0 ? (sales / maxSales) * (chartHeight - 30) : 0;
                        double x = chartStartX + i * (barWidth + barSpacing) + barSpacing / 2;
                        double y = chartStartY + chartHeight - barHeight;

                        gfx.DrawRectangle(XBrushes.SteelBlue, x, y, barWidth, barHeight);

                        string label = dataTable.Rows[i]["formatted_date"].ToString().Trim();
                        XSize labelSize = gfx.MeasureString(label, cellFont);
                        gfx.DrawString(label, cellFont, XBrushes.Black,
                            new XRect(x + (barWidth - labelSize.Width) / 2, chartStartY + chartHeight + 5, labelSize.Width, 15),
                            XStringFormats.TopLeft);

                        string valueLabel = sales.ToString("N0");
                        XSize valueSize = gfx.MeasureString(valueLabel, cellFont);
                        gfx.DrawString(valueLabel, cellFont, XBrushes.Black,
                            new XRect(x + (barWidth - valueSize.Width) / 2, y - 15, valueSize.Width, 15),
                            XStringFormats.TopLeft);
                    }

                    // Легенда
                    string legend = "Продажи по месяцам";
                    XSize legendSize = gfx.MeasureString(legend, cellFont);
                    gfx.DrawRectangle(XBrushes.SteelBlue, chartStartX + chartWidth / 2 - 50, chartStartY - 25, 20, 10);
                    gfx.DrawString(legend, cellFont, XBrushes.Black,
                        new XPoint(chartStartX + chartWidth / 2 - 25, chartStartY - 15));

                    // Подпись
                    string reportDate = $"Отчет создан: {DateTime.Now:dd.MM.yyyy HH:mm}";
                    XSize footerSize = gfx.MeasureString(reportDate, footerFont);
                    gfx.DrawString(reportDate, footerFont, XBrushes.Gray,
                        new XPoint(page.Width - footerSize.Width - 20, page.Height - 20));
                }

                document.Save(filePath);
                document.Close();

                ReportConfirmationWindow confirmationWindow = new ReportConfirmationWindow(filePath);
                confirmationWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}");
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void EmployeeSalesReportButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "Отчет_по_персоналу.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            try
            {
                DataTable dataTable = GetData_EmployeeSalesReport();

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XFont titleFont = new XFont("Arial", 16);
                XFont headerFont = new XFont("Arial", 12);
                XFont cellFont = new XFont("Arial", 10);
                XFont footerFont = new XFont("Arial", 8);
                XFont chartTitleFont = new XFont("Arial", 14);

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    // Заголовок
                    string titleText = "Отчет по продажам сотрудников";
                    XSize titleSize = gfx.MeasureString(titleText, titleFont);
                    gfx.DrawString(titleText, titleFont, XBrushes.Black,
                        new XPoint((page.Width - titleSize.Width) / 2, 40));

                    // Таблица
                    double tableWidth = 400;
                    double startX = (page.Width - tableWidth) / 2;
                    double currentY = 70;
                    double rowHeight = 25;
                    double headerHeight = 30;

                    string[] headers = { "Сотрудник", "Сумма продаж" };
                    double[] columnWidths = { 250, 150 };

                    XPen borderPen = new XPen(XColors.Black, 0.5);
                    gfx.DrawRectangle(borderPen, startX, currentY, tableWidth, headerHeight);

                    double verticalLineX = startX;
                    for (int i = 0; i < columnWidths.Length; i++)
                    {
                        verticalLineX += columnWidths[i];
                        gfx.DrawLine(borderPen,
                            verticalLineX, currentY,
                            verticalLineX, currentY + headerHeight);
                    }

                    double textX = startX;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        gfx.DrawString(headers[i], headerFont, XBrushes.Black,
                            new XRect(textX, currentY + 5, columnWidths[i], headerHeight),
                            XStringFormats.Center);
                        textX += columnWidths[i];
                    }
                    currentY += headerHeight;

                    // Данные таблицы
                    foreach (DataRow row in dataTable.Rows)
                    {
                        gfx.DrawRectangle(borderPen, startX, currentY, tableWidth, rowHeight);

                        verticalLineX = startX;
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            verticalLineX += columnWidths[i];
                            gfx.DrawLine(borderPen,
                                verticalLineX, currentY,
                                verticalLineX, currentY + rowHeight);
                        }

                        gfx.DrawString(row["full_name"].ToString(), cellFont, XBrushes.Black,
                            new XRect(startX, currentY, columnWidths[0], rowHeight),
                            XStringFormats.Center);

                        gfx.DrawString(Convert.ToDecimal(row["total_sales_by_employee"]).ToString("N2") + " ₽",
                            cellFont, XBrushes.Black,
                            new XRect(startX + columnWidths[0], currentY, columnWidths[1], rowHeight),
                            XStringFormats.Center);

                        currentY += rowHeight;
                    }

                    // Диаграмма
                    string chartTitle = "Топ сотрудников по продажам";
                    XSize chartTitleSize = gfx.MeasureString(chartTitle, chartTitleFont);
                    currentY += 50;
                    gfx.DrawString(chartTitle, chartTitleFont, XBrushes.Black,
                        new XPoint((page.Width - chartTitleSize.Width) / 2, currentY));
                    currentY += chartTitleSize.Height + 30;

                    double chartStartY = currentY;
                    double chartHeight = 200;
                    double chartWidth = 500;
                    double chartStartX = (page.Width - chartWidth) / 2;
                    double barWidth = chartWidth / dataTable.Rows.Count * 0.7;
                    double barSpacing = chartWidth / dataTable.Rows.Count * 0.3;

                    double maxSales = dataTable.AsEnumerable()
                        .Select(r => Convert.ToDouble(r["total_sales_by_employee"]))
                        .DefaultIfEmpty(0)
                        .Max();

                    // Оси
                    gfx.DrawLine(borderPen, chartStartX, chartStartY, chartStartX, chartStartY + chartHeight);
                    gfx.DrawLine(borderPen, chartStartX, chartStartY + chartHeight, chartStartX + chartWidth, chartStartY + chartHeight);

                    // Столбцы
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        double sales = Convert.ToDouble(dataTable.Rows[i]["total_sales_by_employee"]);
                        double barHeight = maxSales > 0 ? (sales / maxSales) * (chartHeight - 30) : 0;
                        double x = chartStartX + i * (barWidth + barSpacing) + barSpacing / 2;
                        double y = chartStartY + chartHeight - barHeight;

                        gfx.DrawRectangle(XBrushes.Teal, x, y, barWidth, barHeight);

                        string label = dataTable.Rows[i]["full_name"].ToString();
                        XSize labelSize = gfx.MeasureString(label, cellFont);
                        gfx.DrawString(label, cellFont, XBrushes.Black,
                            new XRect(x + (barWidth - labelSize.Width) / 2, chartStartY + chartHeight + 5, labelSize.Width, 15),
                            XStringFormats.TopLeft);
                    }

                    // Подпись
                    string reportDate = $"Отчет создан: {DateTime.Now:dd.MM.yyyy HH:mm}";
                    XSize footerSize = gfx.MeasureString(reportDate, footerFont);
                    gfx.DrawString(reportDate, footerFont, XBrushes.Gray,
                        new XPoint(page.Width - footerSize.Width - 20, page.Height - 20));
                }

                document.Save(filePath);
                document.Close();

                new ReportConfirmationWindow(filePath).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации: {ex.Message}");
            }
        }
        public void ProductSalesButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "Отчет_продаваемости_товаров.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            try
            {
                DataTable dataTable = GetData_ProductSalesReport();

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XFont titleFont = new XFont("Arial", 16);
                XFont headerFont = new XFont("Arial", 12);
                XFont cellFont = new XFont("Arial", 10);
                XFont footerFont = new XFont("Arial", 8);
                XFont chartTitleFont = new XFont("Arial", 14);

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    // Заголовок
                    string titleText = "Отчет продаваемости товаров";
                    XSize titleSize = gfx.MeasureString(titleText, titleFont);
                    gfx.DrawString(titleText, titleFont, XBrushes.Black,
                        new XPoint((page.Width - titleSize.Width) / 2, 40));

                    // Таблица
                    double tableWidth = 500;
                    double startX = (page.Width - tableWidth) / 2;
                    double currentY = 70;
                    double rowHeight = 25;
                    double headerHeight = 30;

                    string[] headers = { "Блюдо", "Количество", "Выручка" };
                    double[] columnWidths = { 200, 150, 150 };

                    XPen borderPen = new XPen(XColors.Black, 0.5);
                    gfx.DrawRectangle(borderPen, startX, currentY, tableWidth, headerHeight);

                    double verticalLineX = startX;
                    for (int i = 0; i < columnWidths.Length; i++)
                    {
                        verticalLineX += columnWidths[i];
                        gfx.DrawLine(borderPen,
                            verticalLineX, currentY,
                            verticalLineX, currentY + headerHeight);
                    }

                    double textX = startX;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        gfx.DrawString(headers[i], headerFont, XBrushes.Black,
                            new XRect(textX, currentY + 5, columnWidths[i], headerHeight),
                            XStringFormats.Center);
                        textX += columnWidths[i];
                    }
                    currentY += headerHeight;

                    // Данные таблицы
                    foreach (DataRow row in dataTable.Rows)
                    {
                        gfx.DrawRectangle(borderPen, startX, currentY, tableWidth, rowHeight);

                        verticalLineX = startX;
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            verticalLineX += columnWidths[i];
                            gfx.DrawLine(borderPen,
                                verticalLineX, currentY,
                                verticalLineX, currentY + rowHeight);
                        }

                        gfx.DrawString(row["name_dish"].ToString(), cellFont, XBrushes.Black,
                            new XRect(startX, currentY, columnWidths[0], rowHeight),
                            XStringFormats.Center);

                        gfx.DrawString(row["total_quantity_sold"].ToString(), cellFont, XBrushes.Black,
                            new XRect(startX + columnWidths[0], currentY, columnWidths[1], rowHeight),
                            XStringFormats.Center);

                        gfx.DrawString(Convert.ToDecimal(row["total_revenue"]).ToString("N2") + " ₽",
                            cellFont, XBrushes.Black,
                            new XRect(startX + columnWidths[0] + columnWidths[1], currentY, columnWidths[2], rowHeight),
                            XStringFormats.Center);

                        currentY += rowHeight;
                    }

                    // Диаграмма
                    string chartTitle = "Топ продаж по выручке";
                    XSize chartTitleSize = gfx.MeasureString(chartTitle, chartTitleFont);
                    currentY += 50;
                    gfx.DrawString(chartTitle, chartTitleFont, XBrushes.Black,
                        new XPoint((page.Width - chartTitleSize.Width) / 2, currentY));
                    currentY += chartTitleSize.Height + 30;

                    double chartStartY = currentY;
                    double chartHeight = 200;
                    double chartWidth = 500;
                    double chartStartX = (page.Width - chartWidth) / 2;
                    double barWidth = chartWidth / dataTable.Rows.Count * 0.7;
                    double barSpacing = chartWidth / dataTable.Rows.Count * 0.3;

                    double maxRevenue = dataTable.AsEnumerable()
                        .Select(r => Convert.ToDouble(r["total_revenue"]))
                        .DefaultIfEmpty(0)
                        .Max();

                    // Оси
                    gfx.DrawLine(borderPen, chartStartX, chartStartY, chartStartX, chartStartY + chartHeight);
                    gfx.DrawLine(borderPen, chartStartX, chartStartY + chartHeight, chartStartX + chartWidth, chartStartY + chartHeight);

                    // Столбцы
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        double revenue = Convert.ToDouble(dataTable.Rows[i]["total_revenue"]);
                        double barHeight = maxRevenue > 0 ? (revenue / maxRevenue) * (chartHeight - 30) : 0;
                        double x = chartStartX + i * (barWidth + barSpacing) + barSpacing / 2;
                        double y = chartStartY + chartHeight - barHeight;

                        gfx.DrawRectangle(XBrushes.IndianRed, x, y, barWidth, barHeight);

                        string label = dataTable.Rows[i]["name_dish"].ToString();
                        XSize labelSize = gfx.MeasureString(label, cellFont);
                        gfx.DrawString(label, cellFont, XBrushes.Black,
                            new XRect(x + (barWidth - labelSize.Width) / 2, chartStartY + chartHeight + 5, labelSize.Width, 15),
                            XStringFormats.TopLeft);
                    }

                    // Подпись
                    string reportDate = $"Отчет создан: {DateTime.Now:dd.MM.yyyy HH:mm}";
                    XSize footerSize = gfx.MeasureString(reportDate, footerFont);
                    gfx.DrawString(reportDate, footerFont, XBrushes.Gray,
                        new XPoint(page.Width - footerSize.Width - 20, page.Height - 20));
                }

                document.Save(filePath);
                document.Close();

                new ReportConfirmationWindow(filePath).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации: {ex.Message}");
            }
        }
    }
}
