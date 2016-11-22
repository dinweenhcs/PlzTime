using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PlzTime
{
	public partial class ParticipantMasterTableViewController : UITableViewController
	{

		#region ### Properties #################################################
		private SQLiteDatabase _db;
		private List<Participant> ListOfParticipants;
		//public event EventHandler<RowClickedEventArgs> RowClicked;
		#endregion

		#region ### Constructors ###############################################
		public ParticipantMasterTableViewController(IntPtr handle) : base(handle)
		{
		}


		#endregion
		#region ### Deconstructors #############################################
		#endregion

		#region ### Overridden Methods #########################################
		#endregion
		#region ### Event Methods ##############################################
		#endregion
		#region ### Private Methods ############################################
		#endregion
		#region ### Public Methods #############################################
		#endregion

		//#region === Subclasses =================================================
		//public class RowClickedEventArgs : EventArgs
		//{
		//	#region === Properties =============================================
		//	public Participant participant { get; set; }
		//	#endregion

		//	#region === Constructors ===========================================
		//	public RowClickedEventArgs(Participant participant) : base()
		//	{ this.participant = participant; }
		//}
		//#endregion


		//protected class TableSource : UITableViewSource
		//{
		//	private List<Person> items;
		//	protected ParticipantMasterTableViewController parentViewController;
		//	protected string CellIdentifier = "ParticipantTableCell";

		//	public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		//	{
		//		throw new NotImplementedException();
		//	}

		//	public override nint RowsInSection(UITableView tableview, nint section)
		//	{
		//		throw new NotImplementedException();
		//	}
		//}
		//#endregion
	}
}