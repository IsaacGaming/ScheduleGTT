using System.ComponentModel;
using System.Windows;

namespace ScheduleGTT
{
    public partial class DispatcherMainMenu : Window
    {
        public DispatcherMainMenu()
        {
            InitializeComponent();
        }

        private void DispatcherMainMenuWnd_Closing(object sender, CancelEventArgs e) 
            => WndManager.WarningOnClose(sender, e);
    }
}
