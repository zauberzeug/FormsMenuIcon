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

        public CountingPage()
        {
            count++;
            Console.WriteLine("Constructor: " + count + " instances now");

            Content = new ListView {
                ItemsSource = NumberList.Instance.List,
                ItemTemplate = new DataTemplate(typeof(AlertCell)),
            };
        }

        ~CountingPage()
        {
            count--;
            Console.WriteLine("Destructor: " + count + " instances now");
        }
    }

    sealed class NumberList
    {
        // http://csharpindepth.com/Articles/General/Singleton.aspx (Version 6)
        static readonly Lazy<NumberList> lazy = new Lazy<NumberList>(() => new NumberList());

        public static NumberList Instance { get { return lazy.Value; } }

        readonly List<Alert> list = new List<Alert> {
            new Alert{ Type = "A", Message = "a" },
            new Alert{ Type = "B", Message = "b" },
            new Alert{ Type = "C", Message = "c" },
        };

        public List<Alert> List {
            get {
                return new List<Alert>(list);
            }
        }
    }

    class Alert
    {
        public string Type { get; set; }

        public string Message { get; set; }
    }

    public class AlertCell: ViewCell
    {
        public static readonly int RowHeight = Device.OS == TargetPlatform.iOS ? 52 : 58;

        public AlertCell()
        {
            var image = new Image {
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 35,
            };
            var title = new Label {
                LineBreakMode = LineBreakMode.TailTruncation,
                YAlign = TextAlignment.Center,
            };
            var description = new Label {
                LineBreakMode = LineBreakMode.TailTruncation,
                YAlign = TextAlignment.Center,
            };

            title.SetBinding(Label.TextProperty, "Type");
            description.SetBinding(Label.TextProperty, "Message");

            View = new StackLayout {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    image,
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Spacing = 0,
                        Padding = new Thickness(0, -5, 0, 0),
                        Children = {
                            title,
                            description,
                        },
                    },
                },
            };
        }
    }
}
