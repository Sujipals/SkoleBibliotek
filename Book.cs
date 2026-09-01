

namespace LibrarySystem
{
    public class Book
    {
        // Property for the title of the book.
        
        public string Title { get; set; }// string is used because the title is text.

        public string Author { get; set; }// Property for the author of the book.

        // Property for the ISBN
        public string ISBN { get; set; }// ISBN is stored as string because it is an identifier,

        // Property that tells whether the book is borrowed.
        public bool IsBorrowed { get; set; }// bool can be true or false.

        // Constructor used when we create a new Book object.
        public Book(string title, string author, string isbn)
        {
            Title = title;// Store the title parameter in the Title property.

            Author = author;// Store the author parameter in the Author property.

            ISBN = isbn;// Store the ISBN parameter in the ISBN property.

            IsBorrowed = false;// A new book is available.
        }

        // Method that returns the borrowing status as text.
        public string GetStatus()
        {
            if (IsBorrowed)// If IsBorrowed is true, return "Borrowed".
            {
                return "Borrowed";
            }
            return "Available";// Otherwise return "Available".
        }
    }
}