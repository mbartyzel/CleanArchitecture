using System;
namespace Borrowings.Gateway
{
    public class BookBorrowed : DomainEvent
    {
        public string UserCardId { get; private set; }
        public string BookIsbn { get; private set; }

        public BookBorrowed(string userCardId, string bookIsbn)
        {
            UserCardId = userCardId;
            BookIsbn = bookIsbn;
        }
    }
}
