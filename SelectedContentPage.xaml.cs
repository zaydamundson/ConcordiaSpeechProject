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

namespace ConcordiaSpeechProject
{
    /// <summary>
    /// Interaction logic for SelectedContentPage.xaml
    /// </summary>
    public partial class SelectedContentPage : Page
    {
        private Person Item;
        public SelectedContentPage(Person item)
        {
            InitializeComponent();

            Item = item;
            NameText.Text = item.FullName;
            AddressText.Text = item.Address;
            PhoneText.Text = item.PhoneNumber;
            EmailText.Text = item.Email;
            SchoolText.Text = item.HighSchool;
            GradText.Text = item.HSGradYear;
            MajorText.Text = item.PossibleMajor;
            SexText.Text = item.Sex;
            CommentsText.Text = item.Comments;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditContentPage page = new EditContentPage(Item);
            NavigationService.Navigate(page);
        }
    }
}
