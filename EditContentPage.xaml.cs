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
    /// Interaction logic for EditContentPage.xaml
    /// </summary>
    public partial class EditContentPage : Page
    {
        private Person Item;
        public EditContentPage(Person item)
        {
            Item = item;
            InitializeComponent();
            FirstNameEdit.Text = item.FirstName;
            LastNameEdit.Text = item.LastName;
            EmailEdit.Text = item.Email;
            PhoneEdit.Text = item.PhoneNumber;
            StreetEdit.Text = item.StreetAddress;
            CityEdit.Text = item.City;
            stateEdit.Text = item.State;
            ZIPEdit.Text = item.ZIPCode;
            SchoolEdit.Text = item.HighSchool;
            GradYearEdit.Text = item.HSGradYear;
            MajorEdit.Text = item.PossibleMajor;
            SingleDoubleEdit.Text = item.Single_Double_A;
            CommentsEdit.Text = item.Comments;

        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            SelectedContentPage page = new SelectedContentPage(Item);
            NavigationService.Navigate(page);
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {

            if (Item.IsStudent == false)
            {
                DataAccess db = new DataAccess();
                db.EditCoach(SingleDoubleEdit.Text, FirstNameEdit.Text, LastNameEdit.Text, StreetEdit.Text, CityEdit.Text, stateEdit.Text, ZIPEdit.Text,
                                PhoneEdit.Text, EmailEdit.Text, SchoolEdit.Text, CommentsEdit.Text, Item.ID);
            }
            else
            {
                DataAccess db = new DataAccess();
                db.EditStudent(FirstNameEdit.Text, LastNameEdit.Text, StreetEdit.Text, CityEdit.Text, stateEdit.Text, ZIPEdit.Text,
                                PhoneEdit.Text, EmailEdit.Text, SchoolEdit.Text, GradYearEdit.Text, MajorEdit.Text, CommentsEdit.Text, Item.ID);
            }
            

            MessageBox.Show("Saved", "", MessageBoxButton.OK, MessageBoxImage.Information);
            

           
            SelectedContentPage page = new SelectedContentPage(Item);
            NavigationService.Navigate(page);
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (Item.IsStudent == false)
            {
                DataAccess db = new DataAccess();
                db.DeleteCoach(Item.ID);
            }
            else
            {
                DataAccess db = new DataAccess();
                db.DeleteStudent(Item.ID);
            }
                
            MessageBox.Show("Deleted", "", MessageBoxButton.OK, MessageBoxImage.Information);
            MainPage page = new MainPage();
            NavigationService.Navigate(page);
        }
    }
}
