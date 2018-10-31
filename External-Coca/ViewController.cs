using System;

using AppKit;
using Borrowings.Boundary.Response;
using ExternalCoca.MVP;
using Foundation;

namespace ExternalCoca
{
    public partial class ViewController : NSViewController, IBorrowBookView
    {
        string IBorrowBookView.CardIdValue
        {
            get => CardIdLbl.StringValue;
            set => CardIdLbl.StringValue = value;
        }

        string IBorrowBookView.BookIsbnValue
        {
            get => IsbnLbl.StringValue;
            set => IsbnLbl.StringValue = value;
        }

        string IBorrowBookView.InfoMessageValue 
        {
            set => InfoMessageLbl.StringValue = value; 
        }

        IBorrowBookPresenter _presenter;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void borrowBookClicked(AppKit.NSButton sender)
        {
            _presenter.BorrowBook(
                CardIdLbl.StringValue,
                IsbnLbl.StringValue
            );
        }

        void IBorrowBookView.AttachPresenter(IBorrowBookPresenter presenter)
        {
            _presenter = presenter;
            (presenter as BorrowBookCocaPresenter).View = this;
        }
    }
}
