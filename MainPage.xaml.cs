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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Person> people = new List<Person>();
        List<Coach> coaches = new List<Coach>();
        public MainPage()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            
            
                peopleFoundListBox.ItemsSource = people;
           
            
                
            
            peopleFoundListBox.DisplayMemberPath = "FullInfo";
        }

        private void fistNameLookup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lastNameLookup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void emailLookup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void phoneLookup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void schoolLookup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            people.Clear();
            
            // UpdateBinding();
        }

        private void findStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxSelect.SelectedItem == studentOption)
            {
                DataAccess db = new DataAccess();
                people = db.SearchStudents(fistNameLookup.Text, lastNameLookup.Text, emailLookup.Text, phoneLookup.Text, schoolLookup.Text);

                UpdateBinding();
            }
            else if(comboBoxSelect.SelectedItem == coachOption)
            {
                DataAccess db = new DataAccess();
                people = db.SearchCoaches(fistNameLookup.Text, lastNameLookup.Text, emailLookup.Text, phoneLookup.Text, schoolLookup.Text);

                UpdateBinding();
            }
            

            
            
        }

        private void peopleFoundListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSelect.SelectedItem == studentOption)
            {
                Person item = (Person)peopleFoundListBox.SelectedItem;
                SelectedContentPage page = new SelectedContentPage(item);
                NavigationService.Navigate(page);

            }
            else if (comboBoxSelect.SelectedItem == coachOption)
            {
               

            }



        }

       
    }
}
