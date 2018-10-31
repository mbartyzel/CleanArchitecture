using System;
using Borrowings.Boundary.Request;
using Borrowings.Boundary.Response;

namespace ExternalCoca.MVP
{
    public class BorrowBookCocaPresenter : IBorrowBookPresenter
    {
        internal IBorrowBookView View;

        public IBorrowBookUseCase UseCase { get; set; }

        public void BorrowBook(string cardId, string isbn)
        {
            BorrowBookCommand command 
                = BorrowBookCommand.With
                                     .ReaderCardId(cardId)
                                     .BookIsbn(isbn)
                                     .StartDate(DateTime.Now)
                                     .BorrowingDuration(5)
                                   .Get;
           
            UseCase.Handle(command);
        }

        public void ConfirmBorrowing(BorrowingConfirmation confirmation)
        {
            string message = string.Format("{0} was borrowed {1} for {2} days."
                                           ,confirmation.Title
                                           ,confirmation.ReaderFullname
                                           ,confirmation.Duration);


            View.InfoMessageValue = message;
        }
    }
}
