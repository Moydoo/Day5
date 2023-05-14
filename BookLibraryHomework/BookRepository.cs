using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryHomework
{
    internal class BookRepository
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Integrated Security=True;";


        //SELECTING THE VALUES
        public Book[] GetBooks()
        {

            List<Book> books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT BookID, Title, Author, ISBN, Availability FROM Books", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.Id = reader.GetInt32(0);
                            book.Title = reader.GetString(1);
                            book.Author = reader.GetString(2);
                            book.ISBN = reader.GetString(3);
                            book.Availability = reader.GetBoolean(4);
                            books.Add(book);
                        }
                    }
                }
            }
            return books.ToArray();
        }

        //INSERT INTO
        public void CreateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Books (Title, Author, ISBN, Availability) VALUES (@Title, @Author, @ISBN, @Availability)", connection))
                {

                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Availability", book.Availability);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

        }


        public void UpdateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Books SET Title = @Title, Author = @Author, ISBN = @ISBN, Availability = @Availability WHERE BookID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Availability", book.Availability);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteBook(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("DELETE FROM Books WHERE BookID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

        }
    }
}
