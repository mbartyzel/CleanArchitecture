using System;
namespace Borrowings.DomainModel
{
    public class Borrowing
    {
        Reader _reader;
        Book _book;

        public DateTime StartDate { get; }
        public int BorrowingDuration { get; }
        public DateTime ExpectedReturnDate { get; }
        public string BookIsbn { get => _book.Isbn; }
        public string ReaderCardId { get => _reader.CardId; }

        public Borrowing(Reader who, Book whichBook, DateTime fromWhen, int forHowLong)
        {
            _reader = who;
            _book = whichBook;
            StartDate = fromWhen;
            BorrowingDuration = forHowLong;
            ExpectedReturnDate = StartDate.AddDays(forHowLong);
        }

        public bool IsIsbnOf(String isbn)
        {
            return _book.Isbn.Equals(isbn);
        }

        public bool IsReaderCardIdOf(String cardId)
        {
            return _reader.CardId.Equals(cardId);
        }
    }
}
