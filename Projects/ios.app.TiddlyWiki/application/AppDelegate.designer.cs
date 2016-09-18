// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ios.app.TiddlyWiki
{
	partial class AppDelegate
	{
		[Outlet]
		UIKit.UIWindow window { get; set; }

		[Outlet]
		UIKit.UIWindow window2 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (window != null) {
				window.Dispose ();
				window = null;
			}

			if (window2 != null) {
				window2.Dispose ();
				window2 = null;
			}
		}
	}
}
