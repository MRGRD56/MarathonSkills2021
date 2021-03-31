using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MarathonSkills.DesktopApp.Views.Pages;
using MarathonSkills.Model.Additional;
using MarathonSkills.Model.DbModels;

namespace MarathonSkills.DesktopApp.Other
{
    public static class Account
    {
        public static User CurrentUser { get; private set; }

        public static event Action OnUserLogin;
        public static event Action OnUserLogout;

        public static void Login(User user)
        {
            CurrentUser = user;
            OnUserLogin?.Invoke();
        }

        public static void Logout()
        {
            CurrentUser = null;
            OnUserLogout?.Invoke();
        }

        public static Page GetUserNewMainPage() => CurrentUser.Role.RoleId switch
        {
            UserRoles.RunnerRoleId => new RunnerMainPage(),
            UserRoles.AdministratorRoleId => new AdministratorMainPage(),
            UserRoles.CoordinatorRoleId => new CoordinatorMainPage(),
            _ => throw new Exception($"Unknown role: '{CurrentUser.Role.RoleId}'")
        };
    }
}
