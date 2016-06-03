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
			Console.WriteLine("TimeViewController::ViewDidLoad()");


			// Create new Database
			this._database = new SQLiteDatabase();
			this._database.connect();


			// Initialisize Stopwatch
			this._stopwatch = new Stopwatch(1000);
			this._stopwatch.onElapse += (source, e) =>
			{
				this.whatThreadIAm();

				InvokeOnMainThread(delegate
				{
					//this.whatThreadIAm();
					TimeSpan diff = ((Stopwatch)source).getDiff();
					if (((Stopwatch)source).getStart() != null)
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

					this.lbClock.Text = DateTime.UtcNow.ToLongTimeString();
				});
			};
			this._stopwatch.startElapse();


			#region "** UI Methods & Properties ***********************"
			this.btnStartStopwatch.Layer.CornerRadius = 40;
			this.btnStartStopwatch.Enabled = true;
			this.btnStartStopwatch.TouchUpInside += startStopwatch;

			this.btnSplit.Layer.CornerRadius = 40;
			this.btnStartStopwatch.Enabled = false;
			this.btnSplit.TouchUpInside += splitStopwatch;

			this.swtLockStartStopwatch.TouchUpInside += lockStartStopwatch;

			//this.btnAddNewRacer.UserInteractionEnabled = true;
			//this.btnAddNewRacer = false;
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
		private void startStopwatch(object sender, EventArgs e)
		{
			this._stopwatch.resetAndStart();
		}
		private void splitStopwatch(object sender, EventArgs e)
		{

		}
		private void lockStartStopwatch(object sender, EventArgs e)
		{
			if (swtLockStartStopwatch.On)
			{
				this.btnStartStopwatch.Enabled = true;
				this.btnSplit.Enabled = false;
				//this.btnAddNewRacer.UserInteractionEnabled = true;
			}
			else {
				this.btnStartStopwatch.Enabled = false;
				this.btnSplit.Enabled = true;
				//this.btnAddNewRacer.UserInteractionEnabled = false;
			}
		}
		#endregion "#############################################################"
		#region "### Private Methods ############################################"
		private void whatThreadIAm([CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
		{
			Console.WriteLine($"TimeViewController::{method}(): {line}: MainThread={isMainThread}");
		}
		public bool isMainThread => uiThread == Thread.CurrentThread;
		#endregion "#############################################################"
	}
}