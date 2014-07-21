using Xamarin.Forms;

namespace FormsMenuIcon
{
    public static class App
    {
        public static INavigation Navigation { get; set; }

        public static Page GetMainPage()
        {
            return new MainPage();
        }
    }

    public class MainPage : MasterDetailPage
    {
        
        public MainPage()
        {
            Title = "Some Title";
            var master = new MainMenu();
            var detail = new NavigationPage(new FirstPage("FirstPage"));
            
            App.Navigation = App.Navigation ?? detail.Navigation;
            
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
                Children = { Link("A"), Link("B"), Link("C") }
            };
        }

        static Button Link(string name)
        {
            var button = new Button { Text = name };
            button.Clicked += async delegate {
                await App.Navigation.PushAsync(new FirstPage(name));
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