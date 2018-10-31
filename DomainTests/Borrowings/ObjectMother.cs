using System;
using System.Globalization;
using Borrowings.Boundary.Request;
using Borrowings.Boundary.Response;
using Borrowings.DomainModel;
using Borrowings.Gateway;
using DomainTests.Borrowings;
using ExternalInMemoryPersistence;
using ExternalXmlPersistence;
using NUnit.Framework;

namespace Borrowings
{
    public class ObjectMother
    {
        ModelFactory _create = new ModelFactory();

        public Book IsbnOnlyBook(string isbn)
        {
            return _create.Book(isbn, "Any author", "Any title");
		}

        public Reader CardIdOnlyReader(string cardId)
        {
                return _create.Reader(cardId, "Any name", "Any surname");
		}

        public Borrowing BorowingForFiveDays(string cardId, string isbn, DateTime fromWhen)
        {
            return new Borrowing(
                CardIdOnlyReader(cardId), IsbnOnlyBook(isbn),
                fromWhen, 5
            );
        }

        public DateTime DashedDate(string simpleDashedDate)
        {
            return DateTime.ParseExact(simpleDashedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public IBorrowBookPresenter IBorrowBookPresenterMethodInvocationMock(int times) 
        {
            return new InvokeMethodMock(times);
        }

        public void VerifyMock(IMockVerifier mock) 
        {
            mock.Verify();
        }

        public ModelFactory ModelFactory()
        {
            return _create;
        }

        public IRepository PopulatedXmlRepository() 
        {
            ObjectAssembler assembler = new ObjectAssembler(_create);
            IRepository repository = new XmlRepository(assembler);

            _populateRepository(repository);

            return repository;
        }

        public IRepository PopulatedInMemoryRepository()
        {
            IRepository repository = new InMemoryRepository();

            _populateRepository(repository);

            return repository;
        }

        void _populateRepository(IRepository repository)
        {
            Book aBook = _create.Book("isbn-123", "Hemingway", "Old Man and the Sea");
            repository.Store(aBook);

            Reader aReader = _create.Reader("cardId-123", "Jan", "Nowak");
            repository.Store(aReader);
        }

        internal class InvokeMethodMock : IBorrowBookPresenter, IMockVerifier
        {
            int _counter = 0;
            readonly int _expectedInvokes;

            public IBorrowBookUseCase UseCase { set => throw new NotImplementedException(); }

            public InvokeMethodMock(int times)
            {
                _expectedInvokes = times;
            }

            public void ConfirmBorrowing(BorrowingConfirmation confirmation)
            {
                _counter++;
            }

            public void Verify()
            {
                if (_counter != _expectedInvokes)
                {
                    Assert.Fail();
                }
            }

            public void BorrowBook(string cardId, string isbn)
            {
                throw new NotImplementedException();
            }
        }
    }
}
