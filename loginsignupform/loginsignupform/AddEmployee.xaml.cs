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

namespace loginsignupform
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public  Employee NewEmployee { get; set; }
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void NumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string numberText = txtNumber.Text.Trim();
            string designation = txtDesignation.Text.Trim();
            string department = txtDepartment.Text.Trim();      


            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(numberText) || string.IsNullOrEmpty(designation) || string.IsNullOrEmpty(department))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if(numberText.Length != 10)
            {
                MessageBox.Show("Number must be exactly 10 digits");
                return;
            }

            if (!numberText.All(char.IsDigit))
            {
                MessageBox.Show("Number must contain digits only");
                return;
            }


            NewEmployee = new Employee
            {
                EmpName = name,
                EmpEmail = email,
                Number = numberText,
                Designation = designation,
                Department = department
            };

            this.DialogResult = true;
            this.Close();

        }
    }
}
