using AppKit;
using Borrowings.Boundary.Request;
using Borrowings.UseCase;
using ExternalCoca.MVP;
using ExternalInMemoryPersistence;
using Foundation;
using System;

namespace ExternalCoca
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public object SharedApplication { get; private set; }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application

            BorrowBookCocaPresenter presenter = new BorrowBookCocaPresenter();

            IBorrowBookView view = NSApplication.SharedApplication.MainWindow as IBorrowBookView;
            view.AttachPresenter(presenter);

            UseCaseFactory create = new UseCaseFactory();
            IBorrowBookUseCase useCase = create.BoorowBook(new InMemoryRepository());
            useCase.AttachPresenter(presenter);

        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
