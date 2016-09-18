using System;
using System.Security;


using UIKit;

namespace ios.app.TiddlyWiki
{
	public partial class HomeViewController : UIViewController
	{
		public HomeViewController() : base("HomeViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			Title = "HomeViewController";

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void UIButton53_TouchUpInside(UIButton sender)
		{

			var tiddlyWikiViewController = new TiddlyWikiViewController();
			this.NavigationController.PushViewController(tiddlyWikiViewController, true);
			// throw new NotImplementedException();
		}
	}
}


