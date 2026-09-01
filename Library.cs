using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class Library// Library class manages a collection of books and their borrowing status.
    {
        private List<Book> books;// list is generic collection of objects 

        private Dictionary<string, Book> booksByISBN;// Dictionary stores books using ISBN as the key.

        public Library()// Constructor for the Library class.
        {
            books = new List<Book>();// Create an empty list.
            booksByISBN = new Dictionary<string, Book>();// Create an empty dictionary.
        }

        // Method for adding a book.
        public void AddBook(Book book)
        {
            if (booksByISBN.ContainsKey(book.ISBN))// Check whether the ISBN already exists.
            {
                throw new ArgumentException(// Throw an exception if ISBN already exists.
                    "A book with this ISBN already exists.");
            }

            books.Add(book);// Add the book to the List.
            booksByISBN.Add(book.ISBN, book);// Add the same book to the Dictionary.
        }

        // Method that returns all books.
        public List<Book> GetAllBooks()
        {
            return books;// Return the complete list.
        }

        // Search for books by title.
        public List<Book> SearchByTitle(string searchText)
        {
            List<Book> results = books// LINQ Where filters the books.
                .Where(book =>
                    book.Title != null &&// Ensure the title is not null.
                    book.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)// Case-insensitive search for the title.
                .ToList();// Convert the filtered results to a List.
            return results;// Return the matching books.
        }

        // Borrow a book using ISBN.
        public void BorrowBook(string isbn)
        {
            if (!booksByISBN.TryGetValue(isbn, out Book book))// Try to find the book in the Dictionary.
            {
                throw new ArgumentException(// ISBN does not exist.
                    $"No book with ISBN {isbn} was found.");// Throw an exception if the book is not found.
            }

            if (book.IsBorrowed)// Check whether the book is already borrowed.
            {
                throw new BookAlreadyBorrowedException(// Throw our custom exception.
                    $"The book '{book.Title}' is already borrowed.",// Provide a message for the exception.
                    book.ISBN);// Pass the ISBN to the exception constructor.
            }
            book.IsBorrowed = true;// Mark the book as borrowed.
        }

        // Return a book using ISBN.
        public void ReturnBook(string isbn)
        {
            if (!booksByISBN.TryGetValue(isbn, out Book book))// Search for the book using the Dictionary.
            {
                throw new ArgumentException(// ISBN does not exist.
                    $"No book with ISBN {isbn} was found.");
            }

            if (!book.IsBorrowed)// Check if the book is currently borrowed.
            {
                throw new InvalidOperationException(// The book is already available.
                    $"The book '{book.Title}' is not currently borrowed.");
            }

            book.IsBorrowed = false;// Mark the book as available.
        }

        // Get all currently borrowed books.
        public List<Book> GetBorrowedBooks()
        {
            return books// LINQ Where finds borrowed books.
                .Where(book => book.IsBorrowed)
                .ToList();
        }

        // Get all currently available books.
        public List<Book> GetAvailableBooks()
        {
            return books// LINQ Where finds available books.
                .Where(book => !book.IsBorrowed)// Filter for books that are not borrowed.
                .ToList();// Convert the filtered results to a List.
        }
    }
}