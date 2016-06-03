using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PlzTime
{
	public partial class MainViewController : UIViewController
	{
		#region "### Properties #################################################"
		private SQLiteDatabase _database;
		#endregion "#############################################################"

		#region "### Constructors ###############################################"
		public MainViewController(IntPtr handle) : base(handle)
		{
		}
		#endregion "#############################################################"
		#region "### Deconstructors #############################################"
		#endregion "#############################################################"

		#region "### Overridden Methods #########################################"
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Console.WriteLine("MainViewController::ViewDidLoad()");

			// Create new Database
			this._database = new SQLiteDatabase();
			this._database.connect();

			#region "** UI Methods ***********************"
			this.btnResetDatabase.TouchUpInside += (sender, e) =>
			{
				Console.WriteLine($"MainViewController::ViewDidLoad(btnResetDatabase.TouchUpInside): sender={sender}, e={e}");
				this._database.deleteSQLiteDatabase();
				this._database = new SQLiteDatabase();
				Console.WriteLine($"MainViewController::ViewDidLoad(btnResetDatabase.TouchUpInside): Database restored!");
			};
			this.btnLoadParticipants.TouchUpInside += (sender, e) =>
			{
				var participants = new List<Participant>();
				participants.Add(new Participant(true));
				participants.Add(new Participant(true));
				participants.Add(new Participant(true));
			};
			#endregion "**********************************"
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			Console.WriteLine("MainViewController::ViewWillDisappear()");

			this._database.disconnect();
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			Console.WriteLine("MainViewController::ViewWillAppear()");

			this._database.connect();
		}

		#endregion "#############################################################"
	}
}