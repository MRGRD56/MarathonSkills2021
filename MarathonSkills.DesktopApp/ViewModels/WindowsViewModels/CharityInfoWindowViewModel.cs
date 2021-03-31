using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarathonSkills.Model.DbModels;

namespace MarathonSkills.DesktopApp.ViewModels.WindowsViewModels
{
    public class CharityInfoWindowViewModel : BaseViewModel
    {
        public Charity Charity { get; set; }

        public CharityInfoWindowViewModel(Charity charity)
        {
            Charity = charity;
        }
    }
}
