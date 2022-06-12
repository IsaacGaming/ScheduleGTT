using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace ScheduleGTT
{
    public static class WndManager
    {
        /// <summary>
        /// Выводит сообщение об выходе из системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void WarningOnClose(object sender, CancelEventArgs e)
        {
            string text = "Вы хотите закрыть приложение?",
                   caption = "Выход из системы";
            MessageBoxButton btn = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult mBoxResult = MessageBox.Show(text, caption, btn, icon);

            switch (mBoxResult)
            {
                case MessageBoxResult.OK:
                    e.Cancel = false;
                    break;
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        /// <summary>
        /// Расширяющий метод очистки TextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static string ClearTB(this TextBox textBox)
        {
            return string.Empty;
        }

        public static void ExportToExcel(this DataGrid dataGrid)
        {
            try
            {
                //инициализация приложения Excel
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };
                //создает книгу
                Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                //создает лист               
                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                //создание заголовков таблицы
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 50;
                    myRange.Value2 = dataGrid.Columns[j].Header;
                }

                //заполнение данных в таблицу
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGrid.Items.Count; j++)
                    {
                        TextBlock b = dataGrid.Columns[i].GetCellContent(dataGrid.Items[j]) as TextBlock;
                        Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
                //автоподбор размера столбцов
                sheet1.Columns.AutoFit();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
