using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsMenuIcon
{
    public class App
    {
        static MasterDetailPage MDPage;

        public static Page GetMainPage()
        {
            return new NavigationPage(
                MDPage = new MasterDetailPage {
                    Master = new ContentPage {
                        Title = "Master",
                        Content = new StackLayout {
                            Children = { Link("A"), Link("B"), Link("C") }
                        },
                    },
                    Detail = new ContentPage { Content = new Label { Text = "A" } },
                });
        }

        static Button Link(string name)
        {
            var button = new Button { Text = name };
            button.Clicked += delegate {
                MDPage.Detail = new ContentPage { Content = new Label { Text = name } };
                MDPage.IsPresented = false;
            };
            return button;
        }
    }
}