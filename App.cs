using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsMenuIcon
{
    public static class App
    {
        public static Page GetMainPage()
        {
            var MDPage = new MasterDetailPage();
            MDPage.Master = new ContentPage {
                Title = "Master",
                Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null,
                Content = new StackLayout {
                    Padding = 20,
                    Children = {
                        new Button {
                            Text = "Open counting page",
                            Command = new Command(o => {
                                MDPage.Detail = new NavigationPage(new CountingPage());
                                MDPage.IsPresented = false;
                            }),
                        },
                    },
                },
            };
            MDPage.Detail = new NavigationPage(new CountingPage());
            return MDPage;
        }
    }

    class CountingPage: ContentPage
    {
        static int count;

        public CountingPage()
        {
            count++;
            Console.WriteLine("Constructor: " + count + " instances now");

            Content = new ListView {
                ItemsSource = new List<string> { "1", "2", "3" },
                ItemTemplate = new DataTemplate(typeof(CustomCell)),
            };
        }

        ~CountingPage()
        {
            count--;
            Console.WriteLine("Destructor: " + count + " instances now");
        }
    }

    public class CustomCell: ViewCell
    {
        public CustomCell()
        {
            var label = new Label();
            label.SetBinding(Label.TextProperty, ".");
            View = label;
        }
    }
}
