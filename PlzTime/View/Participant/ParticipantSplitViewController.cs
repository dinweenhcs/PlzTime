using Foundation;
using System;
using UIKit;

namespace PlzTime
{
	public partial class ParticipantSplitViewController : UISplitViewController
	{
		#region ### Properties #################################################
		#endregion

		#region ### Constructors ###############################################
		public ParticipantSplitViewController(IntPtr handle) : base(handle)
		{
		}
		#endregion
		#region ### Deconstructors #############################################
		#endregion

		#region ### Overridden Methods #########################################
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var master = ViewControllers[0] as ParticipantMasterNavigationController;
			var detail = ViewControllers[1] as ParticipantDetailTableViewController;
			var table = master.view as ParticipantMasterTableViewController;
		}
		//public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		//{
		//	return base.ShouldAutorotateToInterfaceOrientation(toInterfaceOrientation);
		//}
		#endregion
		#region ### Event Methods ##############################################
		#endregion
		#region ### Private Methods ############################################
		#endregion
		#region ### Public Methods #############################################
		#endregion
	}
}