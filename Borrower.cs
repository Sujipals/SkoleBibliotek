

namespace LibrarySystem
{
    // Borrower is a class used to represent a library customer.
    public class Borrower
    {
        public string Name { get; set; } // Property containing the borrower's name.
        public int Id { get; set; }// Property containing the borrower's ID.
        public Borrower(string name, int id)// Constructor used to create a Borrower object.
        {
            Name = name;// Store the name parameter.
            Id = id;// Store the ID parameter.
        }
    }
}