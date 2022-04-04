using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public List<Student> DisplayAllStudents()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
                var output = connection.Query<Student>("Select * From dbo.Students").ToList();
                return output;
            }
        }

        public void InsertStudent(string firstName, string lastName, string streetAddress, string city, string state, string zIPCode, 
                                string phoneNumber, string email, string highSchool, string hSGradYear, string possibleMajor, string sex)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SpeechData")))
            {
               /* Student newStudent = new Student
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
                    Sex = sex
                };


               */
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
                    Sex = sex
                });
                //Stored procedure to insert data
                connection.Execute("dbo.InsertStudent @FirstName, @LastName, @StreetAddress, @City, @State, @ZIPCode, @PhoneNumber, @Email, @HighSchool, @HSGradYear, @PossibleMajor, @Sex", students);

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