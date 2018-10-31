using Borrowings.Boundary.Request;
using Borrowings.DomainModel;
using Borrowings.Gateway;

namespace Borrowings.UseCase
{
    public class UseCaseFactory
    {
        public IBorrowBookUseCase BoorowBook(IRepository repository) 
        {
            BorrowBookUseCase useCase = new BorrowBookUseCase
            {
                repository = repository,
                create = new ModelFactory()
            };

            return useCase;
        }
    }
}
