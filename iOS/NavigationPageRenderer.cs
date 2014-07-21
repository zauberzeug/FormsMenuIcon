using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace FormsMenuIcon.iOS
{
    [assembly:ExportRenderer(typeof(NavigationPage), typeof(MyNavigationPageRenderer))]

    public class MyNavigationPageRenderer : NavigationRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            NavigationBar.BackItem.Title = "M";
            base.ViewWillAppear(animated);
        }
    }
}

