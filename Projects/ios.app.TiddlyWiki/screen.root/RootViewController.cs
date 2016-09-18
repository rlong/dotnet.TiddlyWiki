using System;

using UIKit;

namespace ios.app.TiddlyWiki
{
	public partial class RootViewController : UIViewController
	{
		public RootViewController() : base("RootViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


