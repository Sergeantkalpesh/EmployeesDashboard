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
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtRegPassword.Password.Trim();
            string confirmPassword = txtConfirmPassword.Password.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.");
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is required");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required");
                return;
            }
            if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Password do not match");
                return;
            }

            MessageBox.Show("Registration Successful! Redirecting to Login...");

            // Open Login Window
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}