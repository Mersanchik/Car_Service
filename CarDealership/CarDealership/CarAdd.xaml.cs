using CarDealership.bd;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для CarAdd.xaml
    /// </summary>
    public partial class CarAdd : Window
    {
        //bd.CarBaseEntities db = new CarBaseEntities();
        public CarAdd()
        {
            InitializeComponent();
            BaseidCustomer.ItemsSource = App.CarEntites.Customers.Select(c => c.Fname).ToList();
        }
        

        private void AddCarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                bd.CarBaseEntities db = new bd.CarBaseEntities();
                int idCustomer = db.Customers.Where(c => c.Fname == BaseidCustomer.Text).Select(c => c.idCustomer).FirstOrDefault();
                bd.Car addCar = new bd.Car
                {
                    Model = Model.Text,
                    Brand = Brand.Text,
                    Year = Convert.ToInt32(Year.Text),
                    Color = Color.Text,
                    Number = Number.Text,
                    id_Customer = idCustomer
                };
                db.Cars.Add(addCar);
                db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!");
                this.Close();
            }
            catch { }
        }

        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
