using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MarathonSkills.DesktopApp.Other;
using MarathonSkills.Shared;

namespace MarathonSkills.DesktopApp.ViewModels
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        public Command GoBackCommand => new(_ => Navigation.GoBack());

        /// <summary>
        /// Осуществляет навигацию к экземпляру страницы.
        /// </summary>
        public Command NavigateCommand => new(o =>
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
        public Command TypeNavigateCommand => new(o =>
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
    }
}
