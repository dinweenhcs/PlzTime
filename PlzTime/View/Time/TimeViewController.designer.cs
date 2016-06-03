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
    [Register ("TimeViewController")]
    partial class TimeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnAddNewRacer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSplit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnStartStopwatch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ClockStoredView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ClockSubview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView HorizontalSeparatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbClock { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbClockSplit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbStopwatch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbStopwatchSplit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swtLockStartStopwatch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView VerticalSeparatorView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddNewRacer != null) {
                btnAddNewRacer.Dispose ();
                btnAddNewRacer = null;
            }

            if (btnSplit != null) {
                btnSplit.Dispose ();
                btnSplit = null;
            }

            if (btnStartStopwatch != null) {
                btnStartStopwatch.Dispose ();
                btnStartStopwatch = null;
            }

            if (ClockStoredView != null) {
                ClockStoredView.Dispose ();
                ClockStoredView = null;
            }

            if (ClockSubview != null) {
                ClockSubview.Dispose ();
                ClockSubview = null;
            }

            if (HorizontalSeparatorView != null) {
                HorizontalSeparatorView.Dispose ();
                HorizontalSeparatorView = null;
            }

            if (lbClock != null) {
                lbClock.Dispose ();
                lbClock = null;
            }

            if (lbClockSplit != null) {
                lbClockSplit.Dispose ();
                lbClockSplit = null;
            }

            if (lbStopwatch != null) {
                lbStopwatch.Dispose ();
                lbStopwatch = null;
            }

            if (lbStopwatchSplit != null) {
                lbStopwatchSplit.Dispose ();
                lbStopwatchSplit = null;
            }

            if (swtLockStartStopwatch != null) {
                swtLockStartStopwatch.Dispose ();
                swtLockStartStopwatch = null;
            }

            if (VerticalSeparatorView != null) {
                VerticalSeparatorView.Dispose ();
                VerticalSeparatorView = null;
            }
        }
    }
}