using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MarathonSkills.DesktopApp.Other;
using MarathonSkills.DesktopApp.Views.Pages;
using MarathonSkills.Model.Additional;
using MarathonSkills.Model.DbModels;
using MarathonSkills.Shared;

namespace MarathonSkills.DesktopApp.ViewModels
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        private bool _isAuthorized;
        private User _currentUser;
        public Command GoBackCommand => new(_ => Navigation.GoBack());

        /// <summary>
        /// Осуществляет навигацию к экземпляру страницы.
        /// </summary>
        public Command NavigateToInstanceCommand => new(o =>
        {
            if (o is Page page)
            {
                Navigation.Navigate(page);
            }
            else
            {
                throw new ArgumentException("Object is not a Page", "CommandParameter");
            }
        });

        /// <summary>
        /// Осуществляет навигацию. В качестве параметра принимает <see cref="Type"/> страницы.
        /// </summary>
        public Command NavigateCommand => new(o =>
        {
            if (o is Type type)
            {
                var newObject = Activator.CreateInstance(type);
                if (newObject is not Page page)
                {
                    throw new ArgumentException("CommandParameter type is not inherited from Page", "CommandParameter");
                }

                Navigation.Navigate(page);
            }
            else
            {
                throw new ArgumentException("Object is not a Type", "CommandParameter");
            }
        });

        private static Window GetNewWindow(object o)
        {
            if (o is Type type)
            {
                var newObject = Activator.CreateInstance(type);
                if (newObject is not Window window)
                {
                    throw new ArgumentException("CommandParameter type is not inherited from Window", "CommandParameter");
                }

                return window;
            }
            else
            {
                throw new ArgumentException("Object is not a Type", "CommandParameter");
            }
        }

        public Command ShowWindowCommand => new(o =>
        {
            var window = GetNewWindow(o);
            window.Show();
        });

        public Command ShowDialogWindowCommand => new(o =>
        {
            var window = GetNewWindow(o);
            window.ShowDialog();
        });

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (Equals(value, _currentUser)) return;
                _currentUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsAuthorized));
                OnPropertyChanged(nameof(IsNotAuthorized));
                OnPropertyChanged(nameof(IsUserRunner));
            }
        }

        public bool IsAuthorized => CurrentUser != null;

        public bool IsNotAuthorized => !IsAuthorized;

        public bool IsUserRunner => IsAuthorized && CurrentUser.Role.RoleId == UserRoles.RunnerRoleId;

        public BaseViewModel()
        {
            Account.OnUserLogin += () => CurrentUser = Account.CurrentUser;
            Account.OnUserLogout += () => CurrentUser = null;
        }

        public Command LogoutCommand => new(_ =>
        {
            var mbox = MessageBox.Show("Выйти из аккаунта?", "Выход", 
                MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (mbox != MessageBoxResult.OK) return;
            Account.Logout();
            Navigation.Navigate(new MainMenuPage());
            Navigation.ClearNavigationStack();
        });

        public Command NavigateToProfileCommand => new(_ =>
        {
            var profilePage = Account.GetUserNewMainPage();
            Navigation.Navigate(profilePage);
        }, _ => IsAuthorized);
    }
}
