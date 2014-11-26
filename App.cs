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
            };
        }

        protected override void OnDisappearing()
        {
            (Content as ListView).RemoveBinding(ListView.ItemsSourceProperty);
            base.OnDisappearing();
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

        readonly List<string> list = new List<string>();

        public List<string> List {
            get {
                return new List<string>(list);
            }
        }
    }
}
