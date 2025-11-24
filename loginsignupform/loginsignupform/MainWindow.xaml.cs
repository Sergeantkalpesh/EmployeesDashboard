
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginsignupform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (username == "" || email == "" || password == "")
            {
                MessageBox.Show("All fields required!");
                return;
            }

            EmployeeDashboard dashboard = new EmployeeDashboard(username, email);
            dashboard.Show();
            this.Close();

        }

        private void GoToRegister(object sender, RoutedEventArgs e)
        {
            SignupWindow signup = new SignupWindow();
            signup.Show();
            this.Close();
        }
    }
}
