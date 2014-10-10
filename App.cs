using System;
using Xamarin.Forms;

namespace FormsMenuIcon
{
    public static class App
    {
        static MasterDetailPage MDPage;

        public static Page GetMainPage()
        {
            MDPage = new MasterDetailPage {
                Master = new ContentPage {
                    Title = "Master",
                    Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null,
                    Content = new Button {
                        Text = "Open detail",
                        Command = new Command(o => {
                            MDPage.Detail = new NavigationPage(new ContentPage());
                            MDPage.IsPresented = false;
                        }),
                    },
                },
                Detail = new NavigationPage(new ContentPage()),
            };
            MDPage.IsPresentedChanged += (sender, e) => Console.WriteLine(DateTime.Now + ": " + MDPage.IsPresented);
            return MDPage;
        }
    }
}
