using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SQLRepositories
{
    internal class PersonsRepository
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=VolleyballDatabase;Integrated Security=True;";
       
        
        //SELECTING THE VALUES
        public Person[] GetPersons()
        {

            List<Person> persons = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName FROM Persons", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person();
                            person.Id = reader.GetInt32(0);
                            person.FirstName = reader.GetString(1);
                            person.LastName = reader.GetString(2);
                            persons.Add(person);
                        }
                    }
                }
            }
            return persons.ToArray();
        }


        //INSERT INTO
        public void CreatePerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Persons (FirstName,LastName) VALUES (@FirstName, @LastName)", connection))
                {

                    command.Parameters.AddWithValue("@FirstName", person.FirstName);
                    command.Parameters.AddWithValue("@LastName", person.LastName);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

        }

        //DELETE
        public void DeletePerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("DELETE FROM Persons WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", person.Id);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} rows affected.");
                }
            }

        }

    }
}
