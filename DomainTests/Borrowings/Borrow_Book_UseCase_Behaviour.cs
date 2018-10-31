using NUnit.Framework;
using Borrowings.UseCase;
using Borrowings;
using Borrowings.Gateway;
using Borrowings.DomainModel;
using Borrowings.Boundary.Response;
using Borrowings.Boundary.Request;
using System;

namespace DomainTests.Borrowings
{
    [TestFixture()]
    public class Borrow_Book_UseCase_Behaviour
    {
        ObjectMother forTest;
        IBorrowBookUseCase useCase;
        IBorrowBookPresenter presenter;
        IRepository repository;
        BorrowBookCommand command;

        string cardId;
        string isbn;
        DateTime startDate;
        int duration;
        
        /**
         * 
         * Scenario: User borrows book.
         * 
         * GIVEN User with reader's card
         * GIVEN Book with unique isbn
         * GIVEN Borrowing start date
         * GIVEN For how long the book will be borrowed
         * 
         * WHEN User borrows book
         * 
         * THEN New borrowing with for the book and the user is added
         * THEN User is informed about sucessfull borrowing
         * THEN System notifies all systems it cooperating with that the book was borrowed
         *
         */
        [Test()]
        public void SCENARIO_User_Borrows_Book()
        {
            GIVEN_User_with_readers_card();
            GIVEN_Book_with_unique_isbn();
            GIVEN_Borrowing_start_date();
            GIVEN_For_how_long_book_will_be_borrowed();

            WHEN_User_borrows_book();

            THEN_New_borrowing_for_the_book_and_the_user_is_added();
            THEN_User_is_informed_about_succesfull_borrowing();
            THEN_System_notifies_all_systems_it_cooperating_with_that_the_book_was_borrowed();
        }

        [SetUp]
        public void SetUp() 
        {
            forTest = new ObjectMother();

            repository = forTest.PopulatedXmlRepository();

            presenter = forTest.IBorrowBookPresenterMethodInvocationMock(1);

            UseCaseFactory create = new UseCaseFactory();
            useCase = create.BoorowBook(repository);
            useCase.AttachPresenter(presenter);
        }

        void GIVEN_User_with_readers_card() 
        {
            cardId = "cardId-123";
        }

        void GIVEN_Book_with_unique_isbn() 
        {
            isbn = "isbn-123";
        }

        void GIVEN_Borrowing_start_date()
        {
            startDate = forTest.DashedDate("16-07-2018");
        }

        void GIVEN_For_how_long_book_will_be_borrowed()
        {
            duration = 5;
        }

        void WHEN_User_borrows_book() 
        {
            command = BorrowBookCommand.With
                                           .ReaderCardId(cardId)
                                           .BookIsbn(isbn)
                                           .StartDate(startDate)
                                           .BorrowingDuration(duration)
                                       .Get;
                                            
            useCase.Handle(command);
        }

        void THEN_New_borrowing_for_the_book_and_the_user_is_added()
        {
            Borrowing borrowing = repository.FindBorrowing("isbn-123", "cardId-123");

            Assert.That(borrowing, Is.Not.Null);
            Assert.That(borrowing.IsIsbnOf("isbn-123"), Is.True);
            Assert.That(borrowing.IsReaderCardIdOf("cardId-123"), Is.True);
            Assert.That(borrowing.BorrowingDuration, Is.EqualTo(5));
            Assert.That(borrowing.StartDate, Is.EqualTo(forTest.DashedDate("16-07-2018")));
            Assert.That(borrowing.ExpectedReturnDate, Is.EqualTo(forTest.DashedDate("21-07-2018")));
		}

        void THEN_User_is_informed_about_succesfull_borrowing()
        {
            forTest.VerifyMock(presenter as IMockVerifier);
		}

        void THEN_System_notifies_all_systems_it_cooperating_with_that_the_book_was_borrowed()
        {
			//Assert.Fail();
		}
    }
}
