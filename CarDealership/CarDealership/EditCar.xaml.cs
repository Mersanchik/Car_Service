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
    /// Логика взаимодействия для EditCar.xaml
    /// </summary>
    public partial class EditCar : Window
    {
        bd.CarBaseEntities db;
        public EditCar(bd.CarBaseEntities dbb, bd.UnderRepair or)
        {
            InitializeComponent();
            this.db = dbb;
            this.DataContext = or;
        }

        private void EditCarEmplClick(object sender, RoutedEventArgs e)
        {
                db.SaveChanges();
                this.Close();
        }

        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
