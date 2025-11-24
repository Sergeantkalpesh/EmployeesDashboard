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
    /// Interaction logic for ModifyEmployee.xaml
    /// </summary>
    public partial class ModifyEmployee : Window
    {
        private Employee _employee;
        public ModifyEmployee(Employee emp)
        {
            InitializeComponent();

            _employee = emp;

            txtName.Text = emp.EmpName;
            txtEmail.Text = emp.EmpEmail;
            txtNumber.Text = emp.Number;
            txtDesignation.Text = emp.Designation;
            txtDepartment.Text = emp.Department;
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                _employee.EmpName = txtName.Text;
                _employee.EmpEmail = txtEmail.Text;

                string number = txtNumber.Text.Trim();
                if (!number.All(char.IsDigit))
                {
                    MessageBox.Show("Number must contain digits only");
                    return;
                }

                if (number.Length != 10)
                {
                    MessageBox.Show("Number must be exactly 10 digits");
                    return;
                }


                _employee.Number = number;
                _employee.Designation = txtDesignation.Text;
                _employee.Department = txtDepartment.Text;

                MessageBox.Show("Employee Updated!");
                this.Close();  // ✔ Close window

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: Please fill the detais carefullly" + ex.Message);
            }
        }
        private void txtNumber_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string pasteText = e.DataObject.GetData(DataFormats.Text) as string;
                if (!pasteText.All(char.IsDigit) || pasteText.Length > 11)
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

    }
}