using System.Windows;
using MarathonSkills.DesktopApp.Other;
using MarathonSkills.DesktopApp.Views.Pages;
using MarathonSkills2021.ViewModels.WindowsViewModels;

namespace MarathonSkills.DesktopApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel => (MainWindowViewModel) DataContext;

        public MainWindow()
        {
            InitializeComponent();

            Navigation.Navigate(new MainMenuPage());
        }
    }
}
