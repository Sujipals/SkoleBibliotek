

using System;

namespace LibrarySystem
{
    // Our custom exception inherits from the built-in Exception class.
    public class BookAlreadyBorrowedException : Exception// Custom exception for when a book is already borrowed.
    {
        public string ISBN { get; }// Extra property containing the ISBN.
        public BookAlreadyBorrowedException(// Constructor for the custom exception.
            string message,// The message to display.
            string isbn)// The ISBN of the book that is already borrowed.
            : base(message)// Call the base class constructor with the message.
        {
            ISBN = isbn;// Store the ISBN.
        }
    }
}