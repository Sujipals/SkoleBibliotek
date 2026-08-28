using System;

namespace Lesson02.Library
{
    public class Book
    {
        // Private fields: data is protected from direct access outside the class.
        private string Title;
        private string Author;
        private string Isbn;
        private int PublicationYear;
        private bool IsOnLoan;

        // Constructor with all information
        public Book(string title, string author, string isbn, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be empty.");
            }

            this.Title = title;
            this.Author = author;
            this.Isbn = isbn;
            this.PublicationYear = publicationYear;
            this.IsOnLoan = false;
        }

        // Overloaded constructor with only title and author
        public Book(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be empty.");
            }

            this.Title = title;
            this.Author = author;
            this.Isbn = "ukendt";
            this.PublicationYear = 0;
            this.IsOnLoan = false;
        }

        // Read-only properties
        public string BookTitle
        {
            get { return Title; }
        }

        public string BookAuthor
        {
            get { return Author; }
        }

        public string BookIsbn
        {
            get { return Isbn; }
        }

        public int BookPublicationYear
        {
            get { return PublicationYear; }
        }

        public bool BookIsOnLoan
        {
            get { return IsOnLoan; }
        }

        // Method for borrowing the book
        public void CheckOut()
        {
            if (IsOnLoan)
            {
                throw new InvalidOperationException(
                    "The book is already on loan.");
            }

            IsOnLoan = true;
        }

        // Method for returning the book
        public void Return()
        {
            IsOnLoan = false;
        }

        /*
         * Access modifier explanations:
         *
         * The fields are private because outside code should not
         * directly change the internal data of the Book object.
         *
         * The properties are public because outside code needs
         * to be able to read information about a book.
         *
         * IsOnLoan is private because the loan status must only
         * be changed through CheckOut() and Return().
         *
         * The class is public because Program needs to create
         * Book objects.
         */
    }
}