using System.Windows;

namespace ScheduleGTT
{
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text, pwd = PwdBox.Password;

            if (login == "admin" && pwd == "Dsa007")
            {
                new MainMenu().Show();
                Close();
            }
            else if (login == "dispatcher" && pwd == "disp123")
            {
                new DispatcherMainMenu().Show();
                Close();
            }
            else 
            {
                if (string.IsNullOrEmpty(login))
                {
                    MessageBox.Show("Нельзя вводить пустой логин.", "Ошибка");
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("Нельзя вводить пустой пароль.", "Ошибка");
                }
                else
                {
                    MessageBox.Show("Введены некорректные данные.", "Ошибка");
                }
            }
        }
    }
}
