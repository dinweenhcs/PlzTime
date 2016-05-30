using Foundation;
using System;
using UIKit;

namespace PlzTime
{
    public partial class TimeRacerTableViewController : UITableViewController
    {
        public TimeRacerTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);


			// btnBack
			this.btnBack.Clicked += (sender, e) =>
			{
				this.DismissViewController(true, null);
			};
		}


    }
}