using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Roles1.ItemsSource = App.CarEntites.Roles.Select(e => e.NameRole).ToList();//вывод роли
        }
        int idUser;
        private void LoginPreviewKeyDown(object sender, KeyEventArgs e)//запрет на пробел 
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        //дизайн
        private void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e)//Скрыть надпись "Пароль" 
        {
            if (Password1.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }


        //системные кнопки
        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Закрыть окно
        {
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Свернуть окно
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AuthorizationClick(object sender, RoutedEventArgs e)//Авторизоваться
        {
            try
            {
                var Admin = App.CarEntites.Administrators.FirstOrDefault(x => x.Login == Login1.Text && (x.Password == Password1.Password) && x.Role.NameRole == Roles1.Text);
                var Empl = App.CarEntites.Employees.FirstOrDefault(x => x.Login == Login1.Text && (x.Password == Password1.Password) && x.Role.NameRole == Roles1.Text);

                if(Login1.Text == null || Password1.Password == null || Roles1.Text == null)
                {
                    MessageBox.Show("Не все данные заполнены!");
                }
                else
                {
                    if(Admin != null)
                    {
                        Administrator adm = new Administrator();
                        adm.Show();
                        this.Close();
                    }
                    else
                    {
                        if(Empl != null)
                        {
                            idUser = Empl.idEmployee;
                            if(idUser == Empl.idEmployee)
                            {
                                WindowEmployee windowEmployee = new WindowEmployee(idUser);
                                windowEmployee.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Данного пользователя не существует!\nПроверьте введённые вами данные!");
                        }
                    }
                }
            }
            catch { }
        }
    }
}
