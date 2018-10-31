using System.Collections.Generic;
using Borrowings.DomainModel;
using Borrowings.Gateway;

namespace ExternalInMemoryPersistence
{
    public class InMemoryRepository : IRepository
    {
        IDictionary<string, Reader> readers;
        IDictionary<string, Book> books;
        List<Borrowing> borrowings;
        ModelFactory create;

        public InMemoryRepository() 
        {
            create = new ModelFactory();
            readers = new Dictionary<string, Reader>();
            books = new Dictionary<string, Book>();
            borrowings = new List<Borrowing>();
        }

		public Book FindBook(string isbn)
        {
            return books[isbn];
        }

        public Reader FindReader(string cardId)
        {
            return readers[cardId];
        }

        public Borrowing FindBorrowing(string isbn, string cardId)
        {
            return borrowings.Find(x => x.IsIsbnOf(isbn) && x.IsReaderCardIdOf(cardId));
        }

        public void Store(Borrowing borrowing)
        {
            borrowings.Add(borrowing); 
        }

        public void Store(Book book)
        {
            books.Add(book.Isbn, book);
        }

        public void Store(Reader reader)
        {
            readers.Add(reader.CardId, reader);
        }
    }
}
