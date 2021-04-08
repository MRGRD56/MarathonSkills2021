using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MarathonSkills.Context;
using MarathonSkills.DesktopApp.Extensions;
using MarathonSkills.DesktopApp.Other;

namespace MarathonSkills.DesktopApp.ViewModels.PagesViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _login = "";
        private bool _isAuthorizationProcess;

        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        public bool IsAuthorizationProcess
        {
            get => _isAuthorizationProcess;
            set
            {
                if (value == _isAuthorizationProcess) return;
                _isAuthorizationProcess = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LoginButtonText));
                OnPropertyChanged(nameof(IsLoginButtonEnabled));
            }
        }

        public string LoginButtonText => IsAuthorizationProcess ? "ВХОД..." : "ВОЙТИ";

        public bool IsLoginButtonEnabled => !IsAuthorizationProcess;

        public Command LoginCommand => new(async o =>
        {
            if (o is not PasswordBox passwordBox) return;

            var syncContext = SynchronizationContext.Current;

            await Task.Run(async () =>
            {
                syncContext.Send(_ => IsAuthorizationProcess = true, null);
                var login = Login?.ToLower()?.Trim() ?? "";
                var password = passwordBox.Password ?? "";
                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                {
                    syncContext.Send(_ =>
                    {
                        IsAuthorizationProcess = false;
                        MessageBox.Show("Введите логин и пароль.", "Авторизация", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                    }, null);
                    return;
                }
                using var db = new AppDbContext();
                await db.Roles.LoadAsync();
                var user = await db.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == login && x.Password == password);

                if (user == null)
                {
                    syncContext.Send(_ => IsAuthorizationProcess = false, null);
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Account.Login(user);
                syncContext.Invoke(() =>
                {
                    IsAuthorizationProcess = false;
                    Navigation.Navigate(Account.GetUserNewMainPage());
                    Navigation.ClearNavigationStack(1);
                });
            });
        });
    }
}
