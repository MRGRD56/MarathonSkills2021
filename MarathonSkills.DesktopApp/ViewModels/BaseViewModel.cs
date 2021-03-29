using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MarathonSkills.DesktopApp.Other;
using MarathonSkills.Shared;

namespace MarathonSkills.DesktopApp.ViewModels
{
    public abstract class BaseViewModel : NotifyPropertyChanged
    {
        public Command GoBackCommand => new(o => Navigation.GoBack());

        public Command NavigateCommand => new(o =>
        {
            if (o is Page page)
            {
                Navigation.Navigate(page);
            }
        });
    }
}
