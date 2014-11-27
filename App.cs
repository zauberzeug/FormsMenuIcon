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
                    Children = {
                        new Button {
                            Text = "Open detail A",
                            Command = new Command(o => {
                                MDPage.Detail = new NavigationPage(new CountingPage{ Title = "A" });
                                MDPage.IsPresented = false;
                            }),
                        },
                        new Button {
                            Text = "Open detail B",
                            Command = new Command(o => {
                                MDPage.Detail = new NavigationPage(new CountingPage{ Title = "B" });
                                MDPage.IsPresented = false;
                            }),
                        },
                    },
                },
            };
            MDPage.Detail = new NavigationPage(new CountingPage{ Title = "A" });
            return MDPage;
        }
    }

    class CountingPage: ContentPage
    {
        static int count;

        static readonly List<Alert> list = new List<Alert> {
            new Alert{ Type = "A", Message = "a" },
            new Alert{ Type = "B", Message = "b" },
            new Alert{ Type = "C", Message = "c" },
        };

        public CountingPage()
        {
            count++;
            Console.WriteLine("Constructor: " + count + " instances now");

            Content = new ListView {
                ItemsSource = list,
                ItemTemplate = new DataTemplate(typeof(AlertCell)),
            };
        }

        ~CountingPage()
        {
            count--;
            Console.WriteLine("Destructor: " + count + " instances now");
        }
    }

    class Alert
    {
        public string Type { get; set; }

        public string Message { get; set; }
    }

    public class AlertCell: ViewCell
    {
        public AlertCell()
        {
            var title = new Label();
            var description = new Label();
            title.SetBinding(Label.TextProperty, "Type");
            description.SetBinding(Label.TextProperty, "Message");
            View = new StackLayout {
                Children = {
                    title,
                    description,
                },
            };
        }
    }
}
