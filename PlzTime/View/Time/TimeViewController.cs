using Foundation;
using System;
using UIKit;
using System.Timers;
using System.Threading;
using System.Runtime.CompilerServices;


namespace PlzTime
{
	public partial class TimeViewController : UIViewController
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
		private Stopwatch _stopwatch;

		public Thread uiThread;
		#endregion "#############################################################"


		#region "### Constructors ###############################################"
		public TimeViewController(IntPtr handle) : base(handle)
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
			Console.WriteLine($"{applicationName}::TimeViewController::ViewDidLoad()");


			// Create new Database
			this._database = new SQLiteDatabase(applicationName + ".sqllite", applicationName + "");
			this._database.connect();


			// Initialisize Stopwatch
			this._stopwatch = new Stopwatch(1000);
			this._stopwatch.onElapse += onStopwatchElapse;
			this._stopwatch.startElapse();


			#region "** UI Methods & Properties ***********************"
			this.btnStartStopwatch.Layer.CornerRadius = 40;
			this.btnStartStopwatch.Enabled = true;
			this.btnStartStopwatch.TouchUpInside += onStartStopwatch;

			this.btnSplit.Layer.CornerRadius = 40;
			this.btnSplit.Enabled = false;
			this.btnSplit.TouchUpInside += onSplitStopwatch;

			this.swtLockStartStopwatch.On = true;
			this.swtLockStartStopwatch.TouchUpInside += onLockStartStopwatch;

			this.btnAddNewRacer.Enabled = true;

			this.lbStopwatch.Text = "--:--";
			this.lbClock.Text = "--:--:--";
			this.lbStopwatchSplit.Text = "--:--";
			this.lbClockSplit.Text = "--:--:--";
			#endregion "***********************************************"
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			Console.WriteLine("TimeViewController::ViewWillDisappear()");

			this._database.disconnect();
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			Console.WriteLine("TimeViewController::ViewWillAppear()");

			this._database.connect();
		}
		#endregion "#############################################################"
		#region "### Event Methods ##############################################"
		private void onStopwatchElapse(object sender, EventArgs e)
		{
			//this.whatThreadIAm();
			InvokeOnMainThread(delegate
			{
				//this.whatThreadIAm();
				TimeSpan diff = ((Stopwatch)sender).getDiff();
				if (((Stopwatch)sender).getStart() != null)
				{

					this.lbStopwatch.Text = (int)diff.TotalMinutes + diff.ToString(@"\:ss");
					//String m = ((int)diff.TotalMinutes).ToString();
					//m = m.PadLeft(2, '0');
					//String s = diff.Seconds.ToString();
					//s = s.PadLeft(2, '0');
				}
				else
				{
					this.lbStopwatch.Text = "00:00";
				}

				this.lbClock.Text = ((Stopwatch)sender).getNow().ToLocalTime().ToLongTimeString();
			});
		}
		private void onStartStopwatch(object sender, EventArgs e)
		{
			this._stopwatch.resetAndStart();
			this.swtLockStartStopwatch.On = false;
			this.onLockStartStopwatch(this, EventArgs.Empty);
		}
		private void onSplitStopwatch(object sender, EventArgs e)
		{

		}
		private void onLockStartStopwatch(object sender, EventArgs e)
		{
			if (swtLockStartStopwatch.On)
			{
				this.btnStartStopwatch.Enabled = true;
				this.btnSplit.Enabled = false;
				this.btnAddNewRacer.Enabled = true;
			}
			else {
				this.btnStartStopwatch.Enabled = false;
				this.btnSplit.Enabled = true;
				this.btnAddNewRacer.Enabled = false;
			}
		}
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