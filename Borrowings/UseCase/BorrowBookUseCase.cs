using System;
using Borrowings.Boundary.Request;
using Borrowings.Gateway;
using Borrowings.Boundary.Response;
using Borrowings.DomainModel;

namespace Borrowings.UseCase
{
    public class BorrowBookUseCase : IBorrowBookUseCase
    {
        IBorrowBookPresenter _presenter;

        internal IRepository repository { private get; set; }

        internal ModelFactory create { private get; set; }

        public void Handle(BorrowBookCommand command) {

            Reader reader = repository.FindReader(command.ReaderCardId);

            Book book = repository.FindBook(command.BookIsbn);

            Borrowing borrowing = create.Borrowing(reader, book, 
                                                   command.StartDate, 
                                                   command.BorrowingDuration);

            repository.Store(borrowing);

            BorrowingConfirmation confirmation 
                  = BorrowingConfirmation.With
                                            .Title(book.Title)
                                            .Author(book.Author)
                                            .ReaderFullname(reader.Fullname)
                                            .BorrowingDuration(command.BorrowingDuration)
                                         .Get;

            _presenter.ConfirmBorrowing(confirmation);
        }

        public void AttachPresenter(IBorrowBookPresenter presenter)
        {
            _presenter = presenter;
            _presenter.UseCase = this;
        }
    }
}
