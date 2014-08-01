using Xamarin.Forms;

namespace FormsMenuIcon
{
    public static class App
    {
        static MasterDetailPage MDPage;

        public static Page GetMainPage()
        {
            return MDPage = new MasterDetailPage {
                Master = new ContentPage {
                    Title = "Master",
                    Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null,
                    Content = new StackLayout {
                        Children = { Link("A"), Link("B"), Link("C") }
                    },
                },
                Detail = new NavigationPage(new ContentPage { Content = new Label { Text = "A" } }),
            };
        }

        static Button Link(string name)
        {
            var button = new Button { Text = name };
            button.Clicked += delegate {
                MDPage.Detail = new NavigationPage(new ContentPage { Content = new Label { Text = name } });
                MDPage.IsPresented = false;
            };
            return button;
        }
    }
}