using System;
using Borrowings;
using Borrowings.Boundary.Request;
using Borrowings.Boundary.Response;
using Borrowings.DomainModel;
using Borrowings.UseCase;
using ExternalInMemoryPersistence;
using ExternalXmlPersistence;

namespace DeliveryCli
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.Write("Type reader's card id: ");
            string cardId = Console.ReadLine();

            Console.Write("Type book's isbn: ");
            string isbn = Console.ReadLine();

            Console.WriteLine();


            IBorrowBookPresenter presenter = new CliBorrowBookPresenter();


            UseCaseFactory create = new UseCaseFactory();

            ObjectMother fakes = new ObjectMother();
            IBorrowBookUseCase useCase = create.BoorowBook(fakes.PopulatedInMemoryRepository());

            useCase.AttachPresenter(presenter);


            presenter.BorrowBook(cardId, isbn);
        }
    }
}
