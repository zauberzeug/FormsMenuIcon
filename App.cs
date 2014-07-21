using Xamarin.Forms;

namespace FormsMenuIcon
{
    public static class App
    {
        public static MasterDetailPage Menu;

        public static Page GetMainPage()
        {
            return Menu = new MainPage();
        }
    }

    public class MainPage : MasterDetailPage
    {
        
        public MainPage()
        {
            Title = "Some Title";
            var master = new MainMenu();
            var detail = new NavigationPage(new FirstPage("FirstPage"));

            Master = master;
            Detail = detail;
        }
    }

    public class MainMenu: ContentPage
    {
        public MainMenu()
        {
            Title = "MainMenu";
            Content = new StackLayout {
                Children = { Link("A"), Link("B"), Link("C") },
                Padding = 20,
            };
        }

        static Button Link(string name)
        {
            var button = new Button { Text = name };
            button.Clicked += async delegate {
                App.Menu.Detail = new NavigationPage(new FirstPage(name));
                App.Menu.IsPresented = false;
            };
            return button;
        }
    }

    public class FirstPage: ContentPage
    {
        public FirstPage(string text)
        {
            Content = new Label{ Text = text };
        }
    }
}