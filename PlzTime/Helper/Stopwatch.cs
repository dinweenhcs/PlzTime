using System;
using System.Threading;
using System.Runtime.CompilerServices;


namespace PlzTime
{

	//public delegate void StopwatchEventHandler(object source, StopwatchEventArgs e);  //*** version: onwn EventArgs ***
	//public class StopwatchEventArgs : EventArgs
	//{
	//	private DateTime _now;
	//	public StopwatchEventArgs(DateTime now)
	//	{
	//		_now = now;
	//	}
	//	public DateTime getEventArg()
	//	{
	//		return _now;
	//	}
	//}
	public delegate void StopwatchEventHandler(object source, EventArgs e);

	public class Stopwatch
	{
		#region "### Properties #################################################"
		private System.Timers.Timer _timer;
		private DateTime _now;
		private DateTime? _start;
		private TimeSpan _diff;

		private Thread _thread;

		public event StopwatchEventHandler onElapse;
		#endregion "#############################################################"

		#region "### Constructors ###############################################"
		public Stopwatch(int interval)
		{
			this._thread = Thread.CurrentThread;
			this._diff = new TimeSpan(0);
			this._start = null;

			this._timer = new System.Timers.Timer();
			this._timer.Enabled = false;
			this._timer.AutoReset = true;
			this._timer.Interval = interval;
			this._timer.Elapsed += timerElapsed;
		}
		#endregion "#############################################################"
		#region "### Deconstructors #############################################"
		#endregion "#############################################################"

		#region "### Private Methods ############################################"
		private bool isClassThread => _thread == Thread.CurrentThread;
		private void whatThreadIAm([CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
		{
			Console.WriteLine($"Stopwatch::{method}(): {line}: MainThread={isClassThread}");
		}
		private void timerElapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			//this._now = e.SignalTime;
			this._now = DateTime.UtcNow;
			this._diff = calculateDiff;

			if (this.onElapse != null)
			{
				//this.onElapse(this, new StopwatchEventArgs(DateTime.UtcNow);
				this.onElapse(this, EventArgs.Empty);
			}
			else
			{
				Console.WriteLine($"Stopwatch::timerElapsed():  this.onElapse == null: Error");
			}

			this.whatThreadIAm();
		}
		private TimeSpan calculateDiff => (_start != null) ? (_now - (DateTime)_start) : _diff;
		//private TimeSpan calculateDiff()  // *** version: long version ***
		//{
		// if (_start != null) 
		// { return _now - (DateTime)_start; }
		// else
		// { return _diff; }
		//return (_start != null) ? (_now - (DateTime)_start) : _diff;
		//}
		#endregion "#############################################################"
		#region "### Public Methods #############################################"
		public void startElapse()
		{
			this._timer.Enabled = true;
		}
		public void stoppElapse()
		{
			this._timer.Enabled = false;
		}
		public void resetAndStart()
		{
			this._timer.Enabled = false;
			_start = DateTime.UtcNow;
			_diff = calculateDiff;
			this._timer.Enabled = true;
		}
		public DateTime getNow()
		{
			return _now;
		}
		public DateTime? getStart()
		{
			return _start;
		}
		public TimeSpan getDiff()
		{
			return _diff;
		}
		#endregion "#############################################################"

	}
}

