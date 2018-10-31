using System;
using Borrowings.DomainModel;
namespace Borrowings.Gateway
{
    public interface IRepository
    {
        Reader FindReader(String cardId);

        Book FindBook(String isbn);

        Borrowing FindBorrowing(string isbn, string cardId);

        void Store(Borrowing borrowing);

        void Store(Book book);

        void Store(Reader reader);
    }
}
