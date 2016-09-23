using GalaSoft.MvvmLight.Views;
using System;

using UIKit;

namespace TabTest.iOS
{
	public partial class ViewController : ControllerBase
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

