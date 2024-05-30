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
    /// Логика взаимодействия для Registration1.xaml
    /// </summary>
    public partial class Registration1 : Window
    {
        public Registration1()
        {
            InitializeComponent();
        }

        private void CloseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Закрыть окно
        {
            this.Close();
        }

        private void MiniMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//Свернуть окно
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)//Добавление сотрудника
        {
            bd.CarBaseEntities db = new bd.CarBaseEntities();
            int idSpec = db.Specializations.Where(c => c.NameSpec == SpecEmployee.Text).Select(c => c.idSpecialization).FirstOrDefault();
            bd.Employee addEmployee = new bd.Employee
            {
                Fname = Fname.Text,
                Name = Name.Text,
                Sname = Sname.Text,
                id_Specialization = idSpec,
                Login = Login.Text,
                Password = Password.Text
            };
            db.Employees.Add(addEmployee);
            db.SaveChanges();
            MessageBox.Show("Данные успешно добавлены");
            this.Close();
        }
    }
}
