// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PlzTime
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLoadParticipants { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLoadParticipantsNew { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLoadPlzRaces { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnResetDatabase { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnResetDatabaseNew { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTuncateTableParticipant { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnUploadParticipants { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbParticipantCountLoaded { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbParticpantCountCreated { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbParticpantCountModified { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView picPlzRace { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLoadParticipants != null) {
                btnLoadParticipants.Dispose ();
                btnLoadParticipants = null;
            }

            if (btnLoadParticipantsNew != null) {
                btnLoadParticipantsNew.Dispose ();
                btnLoadParticipantsNew = null;
            }

            if (btnLoadPlzRaces != null) {
                btnLoadPlzRaces.Dispose ();
                btnLoadPlzRaces = null;
            }

            if (btnResetDatabase != null) {
                btnResetDatabase.Dispose ();
                btnResetDatabase = null;
            }

            if (btnResetDatabaseNew != null) {
                btnResetDatabaseNew.Dispose ();
                btnResetDatabaseNew = null;
            }

            if (btnTuncateTableParticipant != null) {
                btnTuncateTableParticipant.Dispose ();
                btnTuncateTableParticipant = null;
            }

            if (btnUploadParticipants != null) {
                btnUploadParticipants.Dispose ();
                btnUploadParticipants = null;
            }

            if (lbParticipantCountLoaded != null) {
                lbParticipantCountLoaded.Dispose ();
                lbParticipantCountLoaded = null;
            }

            if (lbParticpantCountCreated != null) {
                lbParticpantCountCreated.Dispose ();
                lbParticpantCountCreated = null;
            }

            if (lbParticpantCountModified != null) {
                lbParticpantCountModified.Dispose ();
                lbParticpantCountModified = null;
            }

            if (picPlzRace != null) {
                picPlzRace.Dispose ();
                picPlzRace = null;
            }
        }
    }
}