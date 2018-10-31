// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ExternalCoca
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField CardIdLbl { get; set; }

        [Outlet]
        AppKit.NSTextField InfoMessageLbl { get; set; }

        [Outlet]
        AppKit.NSTextField IsbnLbl { get; set; }

        [Action ("borrowBookClicked:")]
        partial void borrowBookClicked (AppKit.NSButton sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (CardIdLbl != null) {
                CardIdLbl.Dispose ();
                CardIdLbl = null;
            }

            if (InfoMessageLbl != null) {
                InfoMessageLbl.Dispose ();
                InfoMessageLbl = null;
            }

            if (IsbnLbl != null) {
                IsbnLbl.Dispose ();
                IsbnLbl = null;
            }
        }
    }
}
