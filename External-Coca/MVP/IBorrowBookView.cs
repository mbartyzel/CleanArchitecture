using System;
using Borrowings.Boundary.Response;

namespace ExternalCoca
{
    public interface IBorrowBookView
    {
        string CardIdValue { get; set; }

        string BookIsbnValue { get; set; }

        string InfoMessageValue { set; }

        void AttachPresenter(IBorrowBookPresenter presenter);
    }
}
