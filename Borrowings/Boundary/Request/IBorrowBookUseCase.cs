﻿using System;
using Borrowings.Boundary.Response;

namespace Borrowings.Boundary.Request
{
    public interface IBorrowBookUseCase
    {
        void Handle(BorrowBookCommand commad);

        void AttachPresenter(IBorrowBookPresenter presenter);
    }
}
