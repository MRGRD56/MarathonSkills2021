using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;
using MarathonSkills.DesktopApp.Views.Pages;

namespace MarathonSkills.DesktopApp.Other
{
    public static class Navigation
    {
        public static void Navigate(Page page) => App.MainWindow.Frame.Navigate(page);

        public static void GoBack()
        {
            if (App.MainWindow.Frame.CanGoBack)
            {
                App.MainWindow.Frame.GoBack();
            }
        }

        public static void ClearNavigationStack(int notRemovedCount = 0)
        {
            var count = App.MainWindow.Frame.BackStack.Cast<object>().Count();
            for (var i = 0; i < count - notRemovedCount; i++)
            {
                App.MainWindow.Frame.RemoveBackEntry();
            }
        }

        static Navigation()
        {
            App.MainWindow.Frame.Navigated += (sender, args) =>
            {
                var page = (Page) App.MainWindow.Frame.Content;

                if (page is MainMenuPage)
                {
                    App.MainWindow.Title = App.BaseName;
                    App.MainWindow.ViewModel.ShowBigHeader();
                }
                else
                {
                    App.MainWindow.Title = $"{App.BaseName} - {page.Title}";
                    App.MainWindow.ViewModel.ShowSmallHeader();
                }
            };
        }
    }
}
