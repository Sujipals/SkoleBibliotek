
using System;// Import the System namespace for basic functionality.
using System.Collections.Generic;// Import the System and System.Collections.Generic namespaces.

namespace LibrarySystem
{
    
    public class Program
    {
    
        public static void Main(string[] args)
        {
          
            Library library = new Library();//Library object to hold our books.and library operations.

            AddBooks(library);// Add our books to the library.
            bool running = true; // This controls the while loop. Running ia a boolean variable that is true until the user chooses to exit the program.

            // Continue showing the menu until the user chooses 5.
            while (running)//running is true, the loop continues. When the user chooses 5, running becomes false and the loop stops.
            {
                // Display the menu.
                ShowMenu();
                string input = Console.ReadLine();// Read the user's input.

                // TryParse safely converts text into an integer.
                // It returns false instead of crashing if the input
                // is not a number.
                if (!int.TryParse(input, out int choice))//
                {
                    Console.WriteLine(
                        "Invalid input. Please enter a number from 1 to 5.");

                    continue;
                }

                if (choice < 1 || choice > 5)// Check whether the number is between 1 and 5.
                {
                    Console.WriteLine(
                        "Invalid choice. Please enter a number from 1 to 5.");

                    continue;
                }

                // Choose the correct action.
                switch (choice)
                {
                    case 1:
                        ShowAllBooks(library);// Show all books.
                        break;

                    case 2:
                        SearchBook(library);// Search for a book.
                        break;

                    case 3:
                        BorrowBook(library);// Borrow a book.
                        break;

                    case 4:
                        ReturnBook(library);// Return a book.
                        break;

                    case 5:
                        running = false;// Stop the while loop.

                        Console.WriteLine(
                            "Thank you for using the Library System.");

                        break;
                }

                
                Console.WriteLine();
            }
        }

        // Method that creates and adds our six books.
        private static void AddBooks(Library library)
        {
            // Create a Book object and add it to the library.
            Book book1 = new Book(
                "The Hobbit",
                "J.R.R. Tolkien",
                "9780261102217");

            library.AddBook(book1);

            // Create the second book.
            Book book2 = new Book(
                "Harry Potter and the Philosopher's Stone",
                "J.K. Rowling",
                "9780747532699");

            library.AddBook(book2);

            // Create the third book.
            Book book3 = new Book(
                "The Little Prince",
                "Antoine de Saint-Exupery",
                "9780156012195");

            library.AddBook(book3);

            // Create the fourth book.
            Book book4 = new Book(
                "Pride and Prejudice",
                "Jane Austen",
                "9780141439518");

            library.AddBook(book4);

            // Create the fifth book.
            Book book5 = new Book(
                "1984",
                "George Orwell",
                "9780451524935");

            library.AddBook(book5);

            // Create the sixth book.
            Book book6 = new Book(
                "The Great Gatsby",
                "F. Scott Fitzgerald",
                "9780743273565");

            library.AddBook(book6);
        }

        // Method that displays the menu.
        private static void ShowMenu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("        LIBRARY SYSTEM");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Show all books");
            Console.WriteLine("2. Search for a book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==============================");
            Console.Write("Enter your choice (1-5): ");
        }

        // Method that displays all books.
        private static void ShowAllBooks(Library library)
        {
            Console.WriteLine();
            Console.WriteLine("========== ALL BOOKS ==========");

            // Get all books from the Library.
            List<Book> books = library.GetAllBooks();

            // foreach goes through each Book object.
            foreach (Book book in books)
            {
                // Get the status from the Book class.
                string status = book.GetStatus();

                // Display book information.
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Status: {status}");
                Console.WriteLine("------------------------------");
            }
        }

        // Method for searching for a book.
        private static void SearchBook(Library library)
        {
            Console.WriteLine();
            Console.WriteLine("========== SEARCH ==========");

            // Ask the user for a title.
            Console.Write("Enter title or part of title: ");
            string searchText = Console.ReadLine();// Read the user's input for the search text.
            if (string.IsNullOrWhiteSpace(searchText))// Check if the input is empty or whitespace.
            {
                Console.WriteLine("Search text cannot be empty.");
                return;
            }
            List<Book> results =
                library.SearchByTitle(searchText);// Call the SearchByTitle method of the Library class to get a list of books that match the search text.

            if (results.Count == 0)// If no books were found, display a message and return.
            {
                Console.WriteLine("No books were found.");
                return;
            }

            // Display the number of results.
            Console.WriteLine(
                $"Found {results.Count} book(s):");
            
            foreach (Book book in results)// Loop through each book in the results list.
            {
                Console.WriteLine(
                    $"{book.Title} by {book.Author} - {book.GetStatus()}");// Display the title, author, and status of the book.

                Console.WriteLine($"ISBN: {book.ISBN}");
            }
        }

        // Method for borrowing a book.
        private static void BorrowBook(Library library)
        {
            Console.WriteLine();
            Console.WriteLine("========== BORROW BOOK ==========");

            // Ask for ISBN.
            Console.Write("Enter ISBN: ");

            // Read ISBN.
            string isbn = Console.ReadLine();

            // Check if ISBN is empty.
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            try
            {
                // Try to borrow the book.
                library.BorrowBook(isbn);

                // If no exception occurred, borrowing was successful.
                Console.WriteLine(
                    "Book borrowed successfully.");
            }
            catch (BookAlreadyBorrowedException ex)
            {
                // Catch our custom exception.
                Console.WriteLine($"Error: {ex.Message}");

                // Display the extra ISBN property.
                Console.WriteLine($"ISBN: {ex.ISBN}");
            }
            catch (ArgumentException ex)
            {
                // Catch an ISBN that doesn't exist.
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch any unexpected exception.
                Console.WriteLine(
                    $"Unexpected error: {ex.Message}");
            }
            finally
            {
                // finally always runs.
                Console.WriteLine(
                    "Borrow operation finished.");
            }
        }

        // Method for returning a book.
        private static void ReturnBook(Library library)
        {
            Console.WriteLine();
            Console.WriteLine("========== RETURN BOOK ==========");

            // Ask for ISBN.
            Console.Write("Enter ISBN: ");

            // Read ISBN.
            string isbn = Console.ReadLine();

            // Check whether ISBN is empty.
            if (string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            try
            {
                library.ReturnBook(isbn);// Call the ReturnBook method of the Library class.                
                Console.WriteLine(// If no exception occurred, returning was successful.
                    "Book returned successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");// Catch an ISBN that doesn't exist.
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");// Catch an ISBN that is not currently borrowed.
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Unexpected error: {ex.Message}");// Display the error message.
            }
            finally
            {               
                Console.WriteLine(
                    "Return operation finished.");// Display a message indicating that the return operation has finished.
            }
        }
    }
}