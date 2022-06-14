using ScheduleGTT.DataBase;
using System;
using System.Linq;
using System.Windows;
using static ScheduleGTT.DataBase.ScheduleGTT_Context;

namespace ScheduleGTT
{
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private enum Roles
        {
            Adminstrator = 1,
            Dispatcher = 2
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginTB.Text, pwd = PwdBox.Password;

                Users admin = Context.Users.FirstOrDefault(u => u.Login == login && u.Password == pwd && u.UserRole == (int?)Roles.Adminstrator);
                Users dispatcher = Context.Users.FirstOrDefault(u => u.Login == login && u.Password == pwd && u.UserRole == (int?)Roles.Dispatcher);

                if (admin != null)
                {
                    new MainMenu().Show();
                    Close();
                }
                else if (dispatcher != null)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
