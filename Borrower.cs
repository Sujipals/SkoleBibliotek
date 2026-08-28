using System;

namespace Lesson02.Library
{
    public class Borrower
    {
        private string Name;
        private string BorrowerNumber;
        private int NumberOfBooksLoaned;

        // Constructor
        public Borrower(string name, string borrowerNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(borrowerNumber))
            {
                throw new ArgumentException(
                    "Borrower number cannot be empty.");
            }

            this.Name = name;
            this.BorrowerNumber = borrowerNumber;
            this.NumberOfBooksLoaned = 0;
        }

        // Name can be read and changed
        public string BorrowerName
        {
            get { return Name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Name cannot be empty.");
                }

                Name = value;
            }
        }

        // BorrowerNumber can only be read
        public string BorrowerId
        {
            get { return BorrowerNumber; }
        }

        // NumberOfBooksLoaned can only be read
        public int BooksLoaned
        {
            get { return NumberOfBooksLoaned; }
        }

        // Borrow a book
        public void BorrowBook()
        {
            if (NumberOfBooksLoaned >= 5)
            {
                throw new InvalidOperationException(
                    "A borrower cannot have more than 5 books.");
            }

            NumberOfBooksLoaned++;
        }

        // Return a book
        public void ReturnBook()
        {
            if (NumberOfBooksLoaned > 0)
            {
                NumberOfBooksLoaned--;
            }
        }

        /*
         * Access modifier explanations:
         *
         * The fields are private because the internal state of
         * the borrower should be protected from direct changes.
         *
         * BorrowerId is public with only get because the borrower
         * number should be readable but never changed after creation.
         *
         * BooksLoaned is public with only get because the number
         * should only be changed through BorrowBook() and ReturnBook().
         *
         * BorrowerName has a public setter because a borrower may
         * change their name, but the setter validates the new value.
         */
    }
}