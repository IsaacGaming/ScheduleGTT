using System.Windows;
using System.ComponentModel;

namespace ScheduleGTT
{
    internal static class WndManager
    {
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
    }
}
