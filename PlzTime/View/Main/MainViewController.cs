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
		#region "### Properties #################################################"
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
		#endregion "#############################################################"

		#region "### Constructors ###############################################"
		public MainViewController(IntPtr handle) : base(handle)
		{
			this.uiThread = Thread.CurrentThread;
		}
		#endregion "#############################################################"
		#region "### Deconstructors #############################################"
		#endregion "#############################################################"

		#region "### Overridden Methods #########################################"
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Console.WriteLine($"{applicationName}::MainViewController::ViewDidLoad()");

			// Create new Database
			this._database = new SQLiteDatabase(applicationName + ".sqllite", applicationName + "");
			this._database.connect();

			#region "-------- UI Methods & Properties -----------------------"
			this.btnResetDatabase.TouchUpInside += (sender, e) =>
			{
				Console.WriteLine($"MainViewController::ViewDidLoad(btnResetDatabase.TouchUpInside): sender={sender}, e={e}");
				this._database.deleteSQLiteDatabase();
				this._database = new SQLiteDatabase(applicationName + ".sqllite", applicationName + ""); Console.WriteLine($"MainViewController::ViewDidLoad(btnResetDatabase.TouchUpInside): Database restored!");
			};
			this.btnLoadParticipants.TouchUpInside += (sender, e) =>
			{
				var participants = new List<Participant>();
				participants.Add(new Participant(true));
				participants.Add(new Participant(true));
				participants.Add(new Participant(true));
			};
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
		#endregion "#############################################################"

		#region "### Event Methods ##############################################"
		#endregion "#############################################################"
		#region "### Private Methods ############################################"

		public bool isMainThread => uiThread == Thread.CurrentThread;
		private void whatThreadIAm([CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
		{
			Console.WriteLine($"TimeViewController::{method}(): {line}: MainThread={isMainThread}");
		}
		#endregion "#############################################################"
	}
}