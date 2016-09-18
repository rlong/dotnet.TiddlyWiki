using Foundation;
using System;
using UIKit;

namespace ios.app.TiddlyWiki
{
	public partial class TiddlyWikiViewController : UIViewController
	{


		public TiddlyWikiViewController() : base("TiddlyWikiViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NSUrl url = new NSUrl("http://localhost:22023/TiddlyWikiRepository/TiddlyWiki.html");
			NSUrlRequest request = new NSUrlRequest(url);
			webView.LoadRequest(request);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}


