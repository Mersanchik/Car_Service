using CarDealership.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using System.Xml.Linq;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для Registartion.xaml
    /// </summary>
    public partial class Registartion : Window
    {
        bd.CarBaseEntities db;
        public Registartion(bd.CarBaseEntities dn, bd.Employee emp)
        {
            InitializeComponent();
            this.db = dn;
            this.DataContext = emp;
        }

        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Закрыть окно
        {
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Свернуть окно
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)//Редактирование сотрудника
        {
            db.SaveChanges();
            this.Close();
        }
    }
}
