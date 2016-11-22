using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

namespace PlzTime
{
	public partial class MainViewController : UIViewController
	{
		#region ### Properties #################################################
		private static string applicationName = NSBundle.MainBundle.InfoDictionary["CFBundleName"] + "";
		/*
		* 20 Keys : NSBundleResolvedPath ,CFBundleVersion ,NSBundleInitialPath, 
		* CFBundleIdentifier ,NSMainNibFile ,CFBundleIconFile ,CFBundleInfoPlistURL, 
		* CFBundleExecutable ,DTSDKName ,UIStatusBarStyle ,CFBundleDevelopmentRegion, 
		* DTPlatformName ,CFBundleInfoDictionaryVersion ,CFBundleSupportedPlatforms, 
		* CFBundleExecutablePath ,CFBundleDisplayName ,LSRequiresIPhoneOS, 
		* CFBundlePackageType ,CFBundleSignature ,CFBundleName
		*/
		private SQLiteDatabase _database;

		public Thread uiThread;
		#endregion

		#region ### Constructors ###############################################
		public MainViewController(IntPtr handle) : base(handle)
		{
			this.uiThread = Thread.CurrentThread;
		}
		#endregion
		#region ### Deconstructors #############################################
		#endregion

		#region ### Overridden Methods #########################################
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Console.WriteLine($"{applicationName}::MainViewController::ViewDidLoad()");

			// Create new Database Obejct...
			this._database = new SQLiteDatabase(applicationName + ".sqllite", applicationName + "");
			this._database.connect();

			#region "-------- UI Methods & Properties -----------------------"
			this.btnResetDatabase.TouchUpInside += onResetDatabase;
			this.btnResetDatabaseNew.TouchUpInside += onResetDatabase;
			this.btnLoadParticipants.TouchUpInside += onLoadParticipants;
			this.btnLoadParticipantsNew.TouchUpInside += onLoadParticipants;
			#endregion "-----------------------------------------------------"
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
		#endregion

		#region ### Event Methods ##############################################
		private void onResetDatabase(Object sender, EventArgs e)
		{
			Console.WriteLine($"MainViewController::ViewDidLoad.resetDatabase(sender={sender}, e={e})");
			this._database.deleteSQLiteDatabase();
			this._database = new SQLiteDatabase(applicationName + ".sqllite", applicationName + "");
			Console.WriteLine($"MainViewController::ViewDidLoad.resetDatabase(): Database restored!");
		}
		private void onLoadParticipants(Object sender, EventArgs e)
		{
			Console.WriteLine($"MainViewController::ViewDidLoad.loadParticipants(sender={sender}, e={e})");
			var participants = new List<Participant>();
			participants.Add(new Participant(true));
			participants.Add(new Participant(true));
			participants.Add(new Participant(true));

			this._database.connect();
			foreach (Participant paticipant in participants)
			{
				_database._connection.Insert(paticipant);
			}
			_database.disconnect();
			Console.WriteLine($"MainViewController::ViewDidLoad.loadParticipants(): Three new participants created!");
		}
		#endregion

		#region ### Private Methods ############################################
		public bool isMainThread => uiThread == Thread.CurrentThread;
		private void whatThreadIAm([CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
		{
			Console.WriteLine($"TimeViewController::{method}(): {line}: MainThread={isMainThread}");
		}
		#endregion
	}
}