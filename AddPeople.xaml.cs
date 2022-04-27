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
    /// Interaction logic for AddPeople.xaml
    /// </summary>
    public partial class AddPeople : Page
    {
        public AddPeople()
        {
            InitializeComponent();
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxSelect.SelectedItem == studentOption)
            {
                DataAccess db = new DataAccess();
                db.InsertStudent(firstNameAdd.Text, lastNameAdd.Text, addressAdd.Text, cityAdd.Text, stateAdd.Text, zipAdd.Text, phoneAdd.Text,
               emailAdd.Text, schoolAdd.Text, gradYearAdd.Text, majorAdd.Text, sexAdd.Text, commentsAdd.Text);

                firstNameAdd.Text = "";
                lastNameAdd.Text = "";
                addressAdd.Text = "";
                cityAdd.Text = "";
                stateAdd.Text = "";
                zipAdd.Text = "";
                phoneAdd.Text = "";
                emailAdd.Text = "";
                schoolAdd.Text = "";
                gradYearAdd.Text = "";
                majorAdd.Text = "";
                sexAdd.Text = "";
                commentsAdd.Text = "";

                MessageBox.Show("New Student Added", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (comboBoxSelect.SelectedItem == coachOption)
            {
                DataAccess db = new DataAccess();
                db.InsertCoach(firstNameAdd.Text, lastNameAdd.Text, addressAdd.Text, cityAdd.Text, stateAdd.Text, zipAdd.Text, phoneAdd.Text,
               emailAdd.Text, schoolAdd.Text,singleDoubleAdd.Text, commentsAdd.Text );

                firstNameAdd.Text = "";
                lastNameAdd.Text = "";
                addressAdd.Text = "";
                cityAdd.Text = "";
                stateAdd.Text = "";
                zipAdd.Text = "";
                phoneAdd.Text = "";
                emailAdd.Text = "";
                schoolAdd.Text = "";
                singleDoubleAdd.Text = "";
                commentsAdd.Text = "";

                MessageBox.Show("New Coach Added", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
