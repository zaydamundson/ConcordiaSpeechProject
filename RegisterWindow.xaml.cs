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

namespace ConcordiaSpeechProject
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void createAccountBtn_Click(object sender, RoutedEventArgs e)
        {
        if(txtUsername.Text == "" || txtPassword.Password == "" || txtReenterPassword.Password == "")
            {
                MessageBox.Show("Username and Password boxes are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        else if(txtPassword.Password != txtReenterPassword.Password)
            {
                MessageBox.Show("Passwords don't match", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DataAccess db = new DataAccess();

                db.InsertNewRegistration(txtUsername.Text, txtPassword.Password);

                MessageBox.Show("Your account has been successfully ccreated", "", MessageBoxButton.OK, MessageBoxImage.Information);

                txtUsername.Text = "";
                txtPassword.Password = "";
                txtReenterPassword.Password = "";
            }
        }

        private void backToLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
