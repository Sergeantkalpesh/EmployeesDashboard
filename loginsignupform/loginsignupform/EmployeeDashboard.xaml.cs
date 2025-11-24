using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
namespace loginsignupform
{
    /// <summary> 
    /// /// Interaction logic for EmployeeDashboard.xaml 
    /// /// </summary> 
    public partial class EmployeeDashboard : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public EmployeeDashboard(string username, string email)
        {
            InitializeComponent(); Employees = new ObservableCollection<Employee>()
            {
                new Employee {EmpName = username, EmpEmail = email}
            };
            employeeGrid.ItemsSource = Employees;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = (Employee)((FrameworkElement)sender).DataContext;
            ModifyEmployee modify = new ModifyEmployee(emp);
            modify.ShowDialog();
            employeeGrid.Items.Refresh();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = (Employee)((FrameworkElement)sender).DataContext;
            if (MessageBox.Show("Delete this employee?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Employees.Remove(emp);
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEmployee();
            addWindow.Owner = this;

            bool? result = addWindow.ShowDialog();
            if (result == true)
            {
                Employee newEmp = addWindow.NewEmployee;
                if (newEmp != null)
                {
                    Employees.Add(newEmp);
                    employeeGrid.Items.Refresh();
                }
            }
        }

    }
}