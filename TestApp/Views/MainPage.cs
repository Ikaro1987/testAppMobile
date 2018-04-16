using System;
using TestApp.Views;
using Xamarin.Forms;

namespace TestApp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page testPage1, testPage2, testPage3, testPage4, aboutPage, itemsPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    
                    testPage1 = new NavigationPage(new TestPage())
                    {
                        Title = "Test1"
                    };

                    testPage2 = new NavigationPage(new TestPage())
                    {
                        Title = "Test2"
                    };

                    testPage3 = new NavigationPage(new TestPage())
                    {
                        Title = "Test3"
                    };

                    testPage4 = new NavigationPage(new TestPage())
                    {
                        Title = "Test4"
                    };

                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    testPage1.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    testPage1 = new TestPage()
                    {
                        Title = "Test1"
                    };

                    testPage2 = new TestPage()
                    {
                        Title = "Test2"
                    };

                    testPage3 = new TestPage()
                    {
                        Title = "Test3"
                    };

                    testPage4 = new TestPage()
                    {
                        Title = "Test4"
                    };

                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(testPage1);
            Children.Add(testPage2);
            Children.Add(testPage3);
            Children.Add(testPage4);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
