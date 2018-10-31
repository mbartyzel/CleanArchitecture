using System;
namespace Borrowings.Boundary.Response
{
    public class BorrowingConfirmation
    {
        public string Title { get; internal set; }

        public string Author { get; internal set; }

        public string ReaderFullname { get; internal set; }

        public int Duration { get; internal set; }

        internal static Builder With => new Builder();

        BorrowingConfirmation() {}

        internal class Builder
        {
            BorrowingConfirmation _confirmation = new BorrowingConfirmation();

            internal BorrowingConfirmation Get => _confirmation;

            internal Builder Title(string title) 
            {
                _confirmation.Title = title;
                return this;
            }

            internal Builder Author(string author)
            {
                _confirmation.Author = author;
                return this;
            }

            internal Builder ReaderFullname(string fullname)
            {
                _confirmation.ReaderFullname = fullname;
                return this;
            }

            internal Builder BorrowingDuration(int duration)
            {
                _confirmation.Duration = duration;
                return this;
            }
        }

    }
}
