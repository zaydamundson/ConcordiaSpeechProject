using System;

namespace ConcordiaSpeechProject
{
    public class Student
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

        
//Read only to make string which represents a student
    public string FullInfo
        {
            get 
            { 
                return $"{FirstName} {LastName} {Email}";
            }
            
        }


    }

}