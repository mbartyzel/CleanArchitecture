using System;
namespace Borrowings.DomainModel
{
    public class Book
    {
        public string Isbn { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }

        internal Book(string isbn, string author, string title)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
        }
    }
}
