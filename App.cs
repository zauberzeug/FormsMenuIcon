using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsMenuIcon
{
    public class App
    {
        public static Page GetMainPage()
        {   
            var page = new MasterDetailPage();
            page.Master = new MasterPage(page);
            page.Detail = new DetailPage("A");
            page.IsPresentedChanged += delegate {
                page.Title = page.IsPresented ? page.Master.Title : page.Detail.Title;
            };
            page.Appearing += async delegate {
                await Task.Delay(0);
                page.IsPresented = true;
            };
            page.ToolbarItems.Add(new ToolbarItem("Hi!", null, delegate {
                Console.WriteLine("Hi!");
            }));
            return new NavigationPage(page);
        }
    }

    public class MasterPage: ContentPage
    {
        MasterDetailPage masterDetailPage;

        public MasterPage(MasterDetailPage masterDetail)
        {
            Title = "Master";
            Content = new StackLayout {
                Children = { Link("A"), Link("B"), Link("C") }
            };
            this.masterDetailPage = masterDetail;
        }

        Button Link(string name)
        {
            var button = new Button { Text = name };
            button.Clicked += delegate {
                masterDetailPage.Detail = new DetailPage(name);
                masterDetailPage.IsPresented = false;
            };
            return button;
        }
    }

    public class DetailPage: ContentPage
    {
        public DetailPage(string name)
        {
            Title = name;
            Content = new Label { Text = name };
        }
    }
}

