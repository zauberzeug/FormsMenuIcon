using Xamarin.Forms;
using System.Collections.Generic;

namespace FormsMenuIcon
{
    public static class App
    {
        public static MasterDetailPage Menu;
        public static Dictionary<string,Page> DetailPages = new Dictionary<string, Page>();

        public static Page GetMainPage()
        {
            DetailPages.Add("A", new NavigationPage(new DetailPage("Page A")));
            DetailPages.Add("B", new NavigationPage(new DetailPage("Page B")));
            DetailPages.Add("C", new NavigationPage(new DetailPage("Page C")));

            return Menu = new MainPage();
        }
    }

    public class MainPage : MasterDetailPage
    {
        
        public MainPage()
        {
            Title = "Some Title";

            Master = new MainMenu();
            Detail = App.DetailPages["A"];
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
                App.Menu.Detail = App.DetailPages[name];
                App.Menu.IsPresented = false;
            };
            return button;
        }
    }

    public class DetailPage: ContentPage
    {
        public DetailPage(string text)
        {
            Content = new Label{ Text = text };
        }
    }
}