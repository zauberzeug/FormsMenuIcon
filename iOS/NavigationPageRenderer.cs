using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FormsMenuIcon.iOS;
using System.Linq;

[assembly:ExportRenderer(typeof(NavigationPage), typeof(MyNavigationPageRenderer))]


namespace FormsMenuIcon.iOS
{
    public class MyNavigationPageRenderer : NavigationRenderer
    {
      

        public override void ViewWillAppear(bool animated)
        {

            base.ViewWillAppear(animated);
//            NavigationItem.SetLeftBarButtonItem(new MonoTouch.UIKit.UIBarButtonItem(MonoTouch.UIKit.UIBarButtonSystemItem.Bookmarks), true);
            NavigationItem.SetLeftBarButtonItem(new MonoTouch.UIKit.UIBarButtonItem("M", MonoTouch.UIKit.UIBarButtonItemStyle.Bordered, null), true);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.SetLeftBarButtonItem(new MonoTouch.UIKit.UIBarButtonItem("M", MonoTouch.UIKit.UIBarButtonItemStyle.Bordered, null), true);
            NavigationItem.Title = "Oh";
            //var items = NavigationController.NavigationBar.Items;

        }
    }
}

