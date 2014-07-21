using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FormsMenuIcon.iOS;
using System.Linq;

[assembly:ExportRenderer(typeof(ContentPage), typeof(MyNavigationPageRenderer))]


namespace FormsMenuIcon.iOS
{
    public class MyNavigationPageRenderer : PageRenderer
    {
      

        public override void ViewWillAppear(bool animated)
        {

            NavigationItem.SetLeftBarButtonItem(new MonoTouch.UIKit.UIBarButtonItem(MonoTouch.UIKit.UIBarButtonSystemItem.Bookmarks), true);
            base.ViewWillAppear(animated);
        }
    }
}

