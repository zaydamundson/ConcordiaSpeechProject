using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {
        public OperatorWindow()
        {
            //Operator.Content = new MainPage();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Operator.Content = new MainPage();
        }
        //Dark Theme Method
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
        
        //Exit App method
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Operator.Content = new AddPeople();
        }
    }
}
