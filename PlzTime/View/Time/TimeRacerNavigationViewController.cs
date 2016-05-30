using Foundation;
using System;
using UIKit;

namespace PlzTime
{
    public partial class TimeRacerNavigationViewController : UINavigationController
    {
        public TimeRacerNavigationViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//this.NavigationItem.HidesBackButton = true;;
		}
    }
}