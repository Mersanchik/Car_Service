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
using System.Windows.Shapes;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Закрыть окно
        {
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Свернуть окно
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddCustomerClick(object sender, RoutedEventArgs e)//Добавить
        {
            bd.CarBaseEntities db = new bd.CarBaseEntities();
            bd.Customer customer = new bd.Customer
            {
                Fname = Fname.Text,
                Name = Name.Text,
                Sname = Sname.Text,
                Phone = Phone.Text,
                Email = Email.Text
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Данные успешно добавлены!");
            this.Close();
        }
    }
}
