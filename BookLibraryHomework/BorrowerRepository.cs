using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryHomework
{
    internal class BorrowerRepository
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Integrated Security=True;";


        //SELECTING THE VALUES
        public Borrower[] GetBorrowers()
        {

            List<Borrower> borrowers = new List<Borrower>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT BorrowerID, Name, Email, Phone, TotalBorrowedBooks FROM Borrowers", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Borrower borrower = new Borrower();
                            borrower.Id = reader.GetInt32(0);
                            borrower.Name = reader.GetString(1);
                            borrower.Email = reader.GetString(2);
                            borrower.Phone = reader.GetString(3);
                            borrower.TotalBorrowerBooks = reader.GetInt32(4);
                            borrowers.Add(borrower);
                        }
                    }
                }
            }
            return borrowers.ToArray();
        }

        //INSERT INTO
        public void CreateBorrower(Borrower borrower)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Borrowers (Name, Email, Phone, TotalBorrowedBooks) VALUES (@Name, @Email, @Phone, @TotalBorrowedBooks)", connection))
                {

                    command.Parameters.AddWithValue("@Name", borrower.Name);
                    command.Parameters.AddWithValue("@Email", borrower.Email);
                    command.Parameters.AddWithValue("@Phone", borrower.Phone);
                    command.Parameters.AddWithValue("@TotalBorrowedBooks", borrower.TotalBorrowerBooks);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

        }


        public void UpdateBorrower(Borrower borrower)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Borrowers SET Name = @Name, Email = @Email, Phone = @Phone, TotalBorrowedBooks = @TotalBorrowedBooks WHERE BorrowerID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", borrower.Id);
                    command.Parameters.AddWithValue("@Name", borrower.Name);
                    command.Parameters.AddWithValue("@Email", borrower.Email);
                    command.Parameters.AddWithValue("@Phone", borrower.Phone);
                    command.Parameters.AddWithValue("@TotalBorrowedBooks", borrower.TotalBorrowerBooks);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteBorrower(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("DELETE FROM Borrowers WHERE BorrowerID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

        }


    }
}
