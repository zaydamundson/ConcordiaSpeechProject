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
using MaterialDesignThemes.Wpf;

namespace ConcordiaSpeechProject
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

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void toggleTheme(object sender, RoutedEventArgs e)
        {

            ITheme theme = paletteHelper.GetTheme();


            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }


            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }


            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow().Show();
            this.Close();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();



            if (db.CheckLogin(txtUsername.Text, txtPassword.Password))
            {
                new OperatorWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);

                txtUsername.Text = "";
                txtPassword.Password = "";
            }



        }
    }
}
