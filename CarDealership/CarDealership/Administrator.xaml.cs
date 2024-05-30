using CarDealership.bd;
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
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
        }
        bd.CarBaseEntities db = new bd.CarBaseEntities();

        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//закрытие окна
        {
            MainWindow startwindow = new MainWindow();
            startwindow.Show();
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//свернуть окно
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CustomerSelected(object sender, RoutedEventArgs e)//Отдел Клиентов
        {
            InfoCustomer.Visibility = Visibility.Visible;
            InfoEmployee.Visibility = Visibility.Collapsed;
            InfoCar.Visibility = Visibility.Collapsed;
            InfoStatusCar.Visibility = Visibility.Collapsed;
            BaseCustomers.ItemsSource = App.CarEntites.Customers.ToList();
        }

        private void AddCustomerSelected(object sender, RoutedEventArgs e)//Добавление Клиентов
        {
            try
            {
                Customer customer = new Customer();
                customer.Show();
                BaseCustomers.ItemsSource = App.CarEntites.Customers.ToList();
            }
            catch { }
            
        }

        private void DeleteCustomerSelected(object sender, RoutedEventArgs e)//Удаление Клиентов 
        {
            try
            {
                var row = BaseCustomers.SelectedItem as bd.Customer;
                if (row == null)
                {
                    MessageBox.Show("Вы не выбрали строку для удаления", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить клиента?", "Подтверждение удаления",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    App.CarEntites.Customers.Remove(row);
                    App.CarEntites.SaveChanges();
                    BaseCustomers.ItemsSource = App.CarEntites.Customers.ToList();
                }
            }
            catch { }
        }

        private void EmployeesSelected(object sender, RoutedEventArgs e)//Отдел Сотрудников
        {
            InfoCustomer.Visibility = Visibility.Collapsed;
            InfoEmployee.Visibility = Visibility.Visible;
            InfoCar.Visibility = Visibility.Collapsed;
            InfoStatusCar.Visibility = Visibility.Collapsed;
            BaseEmployee.ItemsSource = App.CarEntites.Employees.ToList();
        }

        private void AddEmployeeSelected(object sender, RoutedEventArgs e)//Добавление Сотрудников
        {
            try
            {
                Registration1 addEmplo = new Registration1();
                addEmplo.Show();
                BaseEmployee.ItemsSource = App.CarEntites.Employees.ToList();
            }
            catch { }
        }

        private void EditPositionSelected(object sender, RoutedEventArgs e)//Редактирование Сотрудников
        {
            var row = BaseEmployee.SelectedItem as bd.Employee;
            if (row != null)
            {
                Registartion registartion = new Registartion(App.CarEntites, row);
                registartion.Show();
                BaseEmployee.ItemsSource = App.CarEntites.Employees.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования", "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
        }

        private void DeleteEmployeeSelected(object sender, RoutedEventArgs e)//Удаление Сотрудников
        {
            try
            {
                var row = BaseEmployee.SelectedItem as bd.Employee;
                if (row == null)
                {
                    MessageBox.Show("Вы не выбрали строку для удаления", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить сотрудника?", "Подтверждение удаления",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    App.CarEntites.Employees.Remove(row);
                    App.CarEntites.SaveChanges();
                    BaseEmployee.ItemsSource = App.CarEntites.Employees.ToList();
                }
            }
            catch { }
        }

        private void CarSelected(object sender, RoutedEventArgs e)//Отдел Машин
        {
            InfoCustomer.Visibility = Visibility.Hidden;
            InfoEmployee.Visibility = Visibility.Collapsed;
            InfoCar.Visibility = Visibility.Visible;
            InfoStatusCar.Visibility = Visibility.Collapsed;
            BaseCars.ItemsSource = App.CarEntites.Cars.ToList();
        }

        private void AddCarsSelected(object sender, RoutedEventArgs e)//Добавление Машин
        {
            try
            {
                CarAdd add = new CarAdd();
                add.Show();
                BaseCars.ItemsSource = App.CarEntites.Cars.ToList();
            }
            catch { }
        }

        private void StatusSelected(object sender, RoutedEventArgs e)//Отдел Состояния Машин
        {
            InfoCustomer.Visibility = Visibility.Collapsed;
            InfoEmployee.Visibility = Visibility.Collapsed;
            InfoCar.Visibility = Visibility.Collapsed;
            InfoStatusCar.Visibility = Visibility.Visible;
            BaseStatusCars.ItemsSource = App.CarEntites.UnderRepairs.ToList();
        }

        
    }
}
