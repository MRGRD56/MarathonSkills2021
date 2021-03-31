using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MarathonSkills.DesktopApp.Views.Windows;

namespace MarathonSkills.DesktopApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string BaseName = "Marathon Skills 2021";

        public new static MainWindow MainWindow => (MainWindow) Current.MainWindow;
    }
}
