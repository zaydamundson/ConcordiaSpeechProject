using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;

namespace ConcordiaSpeechProject
{
    public class DataAccess
    {
        public List<Student> GetStudents(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
                var output = connection.Query<Student>("dbo.Get_StudentByLastName @LastName", new {LastName = lastName}).ToList();
                return output;
            }
           
        }
        public List<Person> SearchStudents(string firstname, string lastname, string email, string phone, string highSchool)
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
               
                var output = connection.Query<Person>("dbo.SearchStudents @FirstName, @LastName, @Email, @PhoneNumber, @HighSchool", new { FirstName = firstname, LastName = lastname, Email = email, PhoneNumber = phone, HighSchool = highSchool }).ToList();
                return output;
              


            }

        }

        public List<Person> SearchCoaches(string firstname, string lastname, string email, string phone, string highSchool)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {

                var output = connection.Query<Person>("dbo.SearchCoaches @FirstName, @LastName, @Email, @PhoneNumber, @School", new { FirstName = firstname, LastName = lastname, Email = email, PhoneNumber = phone, School = highSchool }).ToList();
                return output;



            }

        }

        public List<Student> DisplayAllStudents()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
                var output = connection.Query<Student>("Select * From dbo.Students").ToList();
                return output;
            }
        }

        public void InsertStudent(string firstName, string lastName, string streetAddress, string city, string state, string zIPCode, 
                                string phoneNumber, string email, string highSchool, string hSGradYear, string possibleMajor, string sex, string comments)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
               
                List<Student> students = new List<Student>();
                students.Add(new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    StreetAddress = streetAddress,
                    City = city,
                    State = state,
                    ZIPCode = zIPCode,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    HighSchool = highSchool,
                    HSGradYear = hSGradYear,
                    PossibleMajor = possibleMajor,
                    Sex = sex,
                    Comments = comments
                });
                //Stored procedure to insert data
                connection.Execute("dbo.InsertStudent @FirstName, @LastName, @StreetAddress, @City, @State, @ZIPCode, @PhoneNumber, @Email, @HighSchool, @HSGradYear, @PossibleMajor, @Sex, @Comments", students);

            }

           

            
        }

        public void EditPerson(string firstName, string lastName, string streetAddress, string city, string state, string zIPCode,
                                string phoneNumber, string email, string highSchool, string hSGradYear, string possibleMajor, string sex, string comments, int iD)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    StreetAddress = streetAddress,
                    City = city,
                    State = state,
                    ZIPCode = zIPCode,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    HighSchool = highSchool,
                    HSGradYear = hSGradYear,
                    PossibleMajor = possibleMajor,
                    Sex = sex,
                    Comments = comments,
                    ID = iD
                }) ;

                connection.Execute("dbo.EditStudents @FirstName, @LastName, @StreetAddress, @City, @State, @ZIPCode, @PhoneNumber, @Email, @HighSchool, @HSGradYear, @PossibleMajor, @Sex, @Comments, @ID", people);


            }
        }

        public void DeleteStudent(int iD)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person
                {
                    ID = iD
                });
                connection.Execute("dbo.DeleteStudent @ID", people);


            }

        }

        public void InsertCoach(string firstName, string lastName, string streetAddress, string city, string state, string zIPCode,
                               string phoneNumber, string email, string highSchool, string SingleDouble, string comments)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
            
                List<Coach> coaches = new List<Coach>();
                coaches.Add(new Coach
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = streetAddress,
                    City = city,
                    State = state,
                    ZIPCode = zIPCode,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    School = highSchool,
                    Single_Double_A = SingleDouble,
                    Comments = comments
                });
                //Stored procedure to insert data
                connection.Execute("dbo.InsertCoach @Single_Double_A, @FirstName, @LastName, @Address, @City, @State, @ZIPCode, @PhoneNumber, @Email, @School, @Comments", coaches);

            }
        }
        public void InsertNewRegistration(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
                connection.Open();
                SqlCommand command = (SqlCommand)connection.CreateCommand();
                command.CommandText = "dbo.InsertNewRegistration";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Username", SqlDbType.NChar).Value = username;
                command.Parameters.Add("@Password", SqlDbType.NChar).Value = password;
                command.ExecuteNonQuery();
                connection.Close();



               // connection.Execute("dbo.InsertNewRegistration @Username, @Password", $"{username}");
            }

        }

        public bool CheckLogin(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {

                connection.Open();
                SqlCommand command = (SqlCommand)connection.CreateCommand();
                command.CommandText = "dbo.CheckLogin";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Username", SqlDbType.NChar).Value = username;
                command.Parameters.Add("@Password", SqlDbType.NChar).Value = password;

                var val = command.ExecuteReader().HasRows;
                return val;
                
               // connection.Close();


               

            }

        }




    }
}