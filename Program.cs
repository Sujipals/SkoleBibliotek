using System;

namespace Lesson02.Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SKOLEBIBLIOTEK ===");
            Console.WriteLine();

            // Create 3 books.
            // First constructor
            Book book1 = new Book(
                "The Hobbit",
                "J.R.R. Tolkien",
                "9780261102217",
                1937);

            // Second constructor
            Book book2 = new Book(
                "Harry Potter",
                "J.K. Rowling");

            // First constructor again
            Book book3 = new Book(
                "Clean Code",
                "Robert C. Martin",
                "9780132350884",
                2008);

            // Create 2 borrowers
            Borrower borrower1 = new Borrower(
                "Jonas",
                "B001");

            Borrower borrower2 = new Borrower(
                "Claire",
                "B002");

            // Display books
            Console.WriteLine("Books:");
            Console.WriteLine(
                $"{book1.BookTitle} - {book1.BookAuthor}");

            Console.WriteLine(
                $"{book2.BookTitle} - {book2.BookAuthor}");

            Console.WriteLine(
                $"{book3.BookTitle} - {book3.BookAuthor}");

            Console.WriteLine();

            // Display borrowers
            Console.WriteLine("Borrowers:");
            Console.WriteLine(
                $"{borrower1.BorrowerName} - {borrower1.BorrowerId}");

            Console.WriteLine(
                $"{borrower2.BorrowerName} - {borrower2.BorrowerId}");

            Console.WriteLine();

            // Borrower borrows a book
            Console.WriteLine("Borrowing book...");

            book1.CheckOut();
            borrower1.BorrowBook();

            Console.WriteLine(
                $"{borrower1.BorrowerName} borrowed " +
                $"'{book1.BookTitle}'.");

            Console.WriteLine(
                $"Book on loan: {book1.BookIsOnLoan}");

            Console.WriteLine(
                $"Books borrowed: {borrower1.BooksLoaned}");

            Console.WriteLine();

            // Try to borrow the same book again
            Console.WriteLine(
                "Trying to check out the same book again...");

            try
            {
                book1.CheckOut();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(
                    $"Error: {ex.Message}");
            }

            Console.WriteLine();

            // Return the book
            Console.WriteLine("Returning book...");

            book1.Return();
            borrower1.ReturnBook();

            Console.WriteLine(
                $"Book on loan: {book1.BookIsOnLoan}");

            Console.WriteLine(
                $"Books borrowed: {borrower1.BooksLoaned}");

            Console.WriteLine();

            // Test changing the borrower's name
            borrower1.BorrowerName = "Jonas Hansen";

            Console.WriteLine(
                $"Updated borrower name: " +
                $"{borrower1.BorrowerName}");

            Console.WriteLine();

            // Test maximum of 5 books
            Console.WriteLine("=== TEST: MAXIMUM 5 BOOKS ===");

            try
            {
                borrower1.BorrowBook();
                borrower1.BorrowBook();
                borrower1.BorrowBook();
                borrower1.BorrowBook();
                borrower1.BorrowBook();

                Console.WriteLine(
                    $"Books borrowed: {borrower1.BooksLoaned}");

                // Sixth book - should throw exception
                borrower1.BorrowBook();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(
                    $"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Program finished.");
        }
    }
}