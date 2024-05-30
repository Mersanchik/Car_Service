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
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        int idEmpl;
        public WindowEmployee(int idEmployee)
        {
            InitializeComponent();
            idEmpl = idEmployee;
            BaseStatus.ItemsSource = App.CarEntites.UnderRepairs.Where(r => r.id_Employee == idEmpl).ToList();
        }
        
        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Закрыть окно
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void MinimizedMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Свернуть окно
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddUnderRepairClick(object sender, RoutedEventArgs e)
        {
            var row = BaseStatus.SelectedItem as bd.UnderRepair;
            if (row != null)
            {
                EditCar EditStatus = new EditCar(App.CarEntites, row);
                EditStatus.CBrand.IsEnabled = false;
                EditStatus.CModel.IsEnabled = false;
                EditStatus.CYear.IsEnabled = false;
                EditStatus.CColor.IsEnabled = false;
                EditStatus.CNumber.IsEnabled = false;
                EditStatus.ShowDialog();
                BaseStatus.ItemsSource = App.CarEntites.UnderRepairs.Where(r => r.id_Employee == idEmpl).ToList();

            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования");
                return;
            }
        }
    }
}
