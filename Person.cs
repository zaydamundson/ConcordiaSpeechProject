using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcordiaSpeechProject
{
    public class Person
    {
        public string FirstName { get; set; }

        public String LastName { get; set; }

        public String StreetAddress { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String ZIPCode { get; set; }

        public String PhoneNumber { get; set; }

        public String Email { get; set; }

        public String HighSchool { get; set; }

        public string HSGradYear { get; set; }

        public String PossibleMajor { get; set; }

        public String Sex { get; set; }

        public String Comments { get; set; }

        public String Single_Double_A { get; set; }

        public bool Favorite { get; set; }

        public int ID { get; set; }


        //Read only to make string which represents a student
        public string FullInfo
        {
            get
            {
                return $"{FirstName} {LastName} {Email}";
            }

        }

        public string FullName
        {
            get
            {
                return $"{FirstName}{LastName}";
            }
        }

        public string Address
        {
            get
            {
                return $"{StreetAddress}, {City} {State}";
            }
        }
    }
}
