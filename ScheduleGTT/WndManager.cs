using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace ScheduleGTT
{
    internal static class WndManager
    {
        /// <summary>
        /// Выводит сообщение об выходе из системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void WarningOnClose(object sender, CancelEventArgs e)
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
        internal static string ClearTB(this TextBox textBox)
        {
            return string.Empty;
        }
    }
}
