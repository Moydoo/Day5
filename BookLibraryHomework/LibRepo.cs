using BookLibraryHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookLibraryHomework
{
    public class LibRepo
    {
        BookRepository bookRepository = new BookRepository();
        BorrowerRepository borrowerRepository = new BorrowerRepository();
        public void HandleBooks()
        {
            Console.WriteLine("\n##### BOOKS OPTIONS #####");
            Console.WriteLine("[1] Create a new book");
            Console.WriteLine("[2] Read book information");
            Console.WriteLine("[3] Update book information");
            Console.WriteLine("[4] Delete book information");
            Console.WriteLine("[0] Back to main menu");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {

                //CREATING NEW BOOK
                case 1:

                    Console.WriteLine("Creating a new book...\n");

                    Book book = new Book();

                    while (string.IsNullOrEmpty(book.Title))
                    {
                        Console.Write("Enter the book title: ");
                        book.Title = Console.ReadLine();

                        if (string.IsNullOrEmpty(book.Title))
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    }

                    while (string.IsNullOrEmpty(book.Author))
                    {
                        Console.Write("Enter the book author: ");
                        book.Author = Console.ReadLine();

                        if (string.IsNullOrEmpty(book.Author))
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    }

                    while (string.IsNullOrEmpty(book.ISBN))
                    {
                        Console.Write("Enter the book ISBN: ");
                        book.ISBN = Console.ReadLine();

                        if (string.IsNullOrEmpty(book.ISBN))
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    }

                    bool? availability = null;
                    do
                    {
                        Console.Write("Enter the book availability (true or false): ");
                        if (bool.TryParse(Console.ReadLine(), out bool value))
                        {
                            availability = value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    } while (availability == null);

                    book.Availability = availability.Value;

                    Console.WriteLine("Book created successfully.");

                    bookRepository.CreateBook(book);
                    Console.WriteLine("\nBook has been created\n");
                    break;

                //READING ALL BOOKS
                case 2:
                    Book[] books = bookRepository.GetBooks();

                    foreach (Book book1 in books)
                    {
                        Console.WriteLine($"Id of the book: {book1.Id}\n" +
                            $"Name of the book: {book1.Title}\n" +
                            $"Author of the book: {book1.Author}\n" +
                            $"ISBN of the book: {book1.ISBN}\n" +
                            $"Is available: {book1.Availability}\n");
                    }
                    break;
                case 3:
                    //Update book
                    // Get the book ID from the user
                    Book[] bookItem = bookRepository.GetBooks();
                    Console.Write("Enter the book ID: ");
                    if (int.TryParse(Console.ReadLine(), out int bookId))
                    {
                        // Find the book with the given ID
                        Book bookToUpdate = null;
                        foreach (Book book2 in bookItem)
                        {
                            if (book2.Id == bookId)
                            {
                                bookToUpdate = book2;
                                break;
                            }
                        }

                        if (bookToUpdate != null)
                        {
                            // Display the current values of the book
                            Console.WriteLine("Current book values:");
                            Console.WriteLine($"Title: {bookToUpdate.Title}");
                            Console.WriteLine($"Author: {bookToUpdate.Author}");
                            Console.WriteLine($"ISBN: {bookToUpdate.ISBN}");
                            Console.WriteLine($"Availability: {bookToUpdate.Availability}");

                            // Prompt the user for new values and update the book
                            Console.Write("Enter the new title (press Enter to skip): ");
                            string newTitle = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newTitle))
                            {
                                bookToUpdate.Title = newTitle;
                            }

                            Console.Write("Enter the new author (press Enter to skip): ");
                            string newAuthor = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newAuthor))
                            {
                                bookToUpdate.Author = newAuthor;
                            }

                            Console.Write("Enter the new ISBN (press Enter to skip): ");
                            string newISBN = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newISBN))
                            {
                                bookToUpdate.ISBN = newISBN;
                            }

                            Console.Write("Enter the new availability (true or false) (press Enter to skip): ");
                            string newAvailabilityInput = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newAvailabilityInput) && bool.TryParse(newAvailabilityInput, out bool newAvailability))
                            {
                                bookToUpdate.Availability = newAvailability;
                            }

                            // Update the book in the database
                            bookRepository.UpdateBook(bookToUpdate);
                        }
                        else
                        {
                            Console.WriteLine($"No book found with ID {bookId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid book ID");
                    }
                    break;
                case 4:
                    // Delete book
                    Console.Write("Enter the ID of the book you want to delete: ");
                    int choosedBookId = int.Parse(Console.ReadLine());
                    bookRepository.DeleteBook(choosedBookId);
                    break;
                case 0:
                    Console.WriteLine("Going back to main menu");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        public void HandleBorrowers()
        {
            Console.WriteLine("\n##### BORROWERS OPTIONS #####");
            Console.WriteLine("[1] Create a new borrower");
            Console.WriteLine("[2] Read borrower information");
            Console.WriteLine("[3] Update borrower information");
            Console.WriteLine("[4] Delete borrower information");
            Console.WriteLine("[0] Back to main menu");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //Create New borrower
                    Console.WriteLine("Creating a new borrower...\n");

                    Borrower borrower = new Borrower();

                    while (string.IsNullOrEmpty(borrower.Name))
                    {
                        Console.Write("Enter the borrower name: ");
                        borrower.Name = Console.ReadLine();

                        if (string.IsNullOrEmpty(borrower.Name))
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    }

                    while (string.IsNullOrEmpty(borrower.Email))
                    {
                        Console.Write("Enter the borrower e-mail: ");
                        borrower.Email = Console.ReadLine();

                        if (string.IsNullOrEmpty(borrower.Email))
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    }

                    while (string.IsNullOrEmpty(borrower.Phone))
                    {
                        Console.Write("Enter the borrower Phone: ");
                        borrower.Phone = Console.ReadLine();

                        if (string.IsNullOrEmpty(borrower.Phone))
                        {
                            Console.WriteLine("Invalid value, please try again.");
                        }
                    }
                    Console.Write("Enter total amount of borrowed books: ");
                    borrower.TotalBorrowerBooks = int.Parse(Console.ReadLine());


                    borrowerRepository.CreateBorrower(borrower);
                    Console.WriteLine("\n Created new borrower");
                    break;
                case 2:
                    //Read borrowers
                    Borrower[] borrowers = borrowerRepository.GetBorrowers();

                    foreach (Borrower borrower1 in borrowers)
                    {
                        Console.WriteLine($"Borrower Id: {borrower1.Id}\n" +
                            $"Borrower name: {borrower1.Name}\n" +
                            $"Borrower Email: {borrower1.Email}\n" +
                            $"Borrower Phone: {borrower1.Phone} \n" +
                            $"Total borrowed books by a borrower: {borrower1.TotalBorrowerBooks} \n");
                    }
                    break;
                case 3:
                    //Update book
                    // Get the book ID from the user
                    Borrower[] borrowerItem = borrowerRepository.GetBorrowers();
                    Console.Write("Enter the borrower ID: ");
                    if (int.TryParse(Console.ReadLine(), out int borrowerId))
                    {
                        // Find the book with the given ID
                        Borrower borrowerToUpdate = null;
                        foreach (Borrower borrower2 in borrowerItem)
                        {
                            if (borrower2.Id == borrowerId)
                            {
                                borrowerToUpdate = borrower2;
                                break;
                            }
                        }

                        if (borrowerToUpdate != null)
                        {
                            // Display the current values of the borrower
                            Console.WriteLine("Current borrower values:");
                            Console.WriteLine($"Title: {borrowerToUpdate.Name}");
                            Console.WriteLine($"Author: {borrowerToUpdate.Email}");
                            Console.WriteLine($"ISBN: {borrowerToUpdate.Phone}");
                            Console.WriteLine($"Availability: {borrowerToUpdate.TotalBorrowerBooks}");

                            // Prompt the user for new values and update the borrower
                            Console.Write("Enter the new Name (press Enter to skip): ");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newName))
                            {
                                borrowerToUpdate.Name = newName;
                            }

                            Console.Write("Enter the new Email (press Enter to skip): ");
                            string newEmail = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newEmail))
                            {
                                borrowerToUpdate.Email = newEmail;
                            }

                            Console.Write("Enter the new Phone (press Enter to skip): ");
                            string newPhone = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newPhone))
                            {
                                borrowerToUpdate.Phone = newPhone;
                            }

                            Console.Write("Enter the new amount of borrowed books (press Enter to skip): ");
                            string newTotalBorrowedBooks = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newTotalBorrowedBooks))
                            {
                                borrowerToUpdate.TotalBorrowerBooks = int.Parse(newTotalBorrowedBooks);
                            }

                            // Update the book in the database
                            borrowerRepository.UpdateBorrower(borrowerToUpdate);
                        }
                        else
                        {
                            Console.WriteLine($"No book found with ID {borrowerId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid borrower ID");
                    }
                    break;
                case 4:
                    // Delete borrower
                    Console.Write("Enter the ID of the borrower you want to delete: ");
                    int choosedBorrowerId = int.Parse(Console.ReadLine());
                    borrowerRepository.DeleteBorrower(choosedBorrowerId);
                    Console.WriteLine($"\nDeleted an user with {choosedBorrowerId} ID");
                    break;
                case 0:
                    Console.WriteLine("Going back to main menu");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
