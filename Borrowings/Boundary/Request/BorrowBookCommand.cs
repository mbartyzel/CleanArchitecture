using System;
namespace Borrowings.Boundary.Request
{
    public class BorrowBookCommand
    {
        public string ReaderCardId { get; set; }

        public string BookIsbn { get; set; }

        public DateTime StartDate { get; set; }

        public int BorrowingDuration { get; set; }

        public static Builder With => new Builder();

        public class Builder
        {
            BorrowBookCommand _command = new BorrowBookCommand();

            public BorrowBookCommand Get => _command;

            public Builder ReaderCardId(string cardId)
            {
                _command.ReaderCardId = cardId;
                return this; 
            }

            public Builder BookIsbn(string isbn)
            {
                _command.BookIsbn = isbn;
                return this;
            }

            public Builder StartDate(DateTime date)
            {
                _command.StartDate = date;
                return this;
            }

            public Builder BorrowingDuration(int duration)
            {
                _command.BorrowingDuration = duration;
                return this;
            }
        }
    }
}
