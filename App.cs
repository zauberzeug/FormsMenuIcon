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
                        Children = { MenuLink("A"), MenuLink("B"), MenuLink("C") }
                    },
                },
                Detail = new NavigationPage(CreateContentPage("A")),
            };
        }

        static Button MenuLink(string name)
        {
            return new Button {
                Text = name,
                Command = new Command(o => {
                    MDPage.Detail = new NavigationPage(CreateContentPage(name));
                    MDPage.IsPresented = false;
                }),
            };
        }

        static Button Link(string name)
        {
            return new Button {
                Text = name,
                Command = new Command(o => MDPage.Detail.Navigation.PushAsync(CreateContentPage(name))),
            };
        }

        static ContentPage CreateContentPage(string text)
        {
            return new ContentPage { Title = text, Content = Link(text + ".sub") };
        }
    }
}