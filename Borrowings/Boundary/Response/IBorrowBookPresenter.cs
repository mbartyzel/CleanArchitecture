using System;
using Borrowings.Boundary.Request;

namespace Borrowings.Boundary.Response
{
    public interface IBorrowBookPresenter 
    {
        IBorrowBookUseCase UseCase { set; }

        void ConfirmBorrowing(BorrowingConfirmation confirmation);

        void BorrowBook(string cardId, string isbn);
    }
}
