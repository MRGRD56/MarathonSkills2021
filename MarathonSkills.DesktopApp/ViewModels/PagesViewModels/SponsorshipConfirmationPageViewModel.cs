using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarathonSkills.DesktopApp.ViewModels;
using MarathonSkills.Model.DbModels;

namespace MarathonSkills.DesktopApp.ViewModels.PagesViewModels
{
    public class SponsorshipConfirmationPageViewModel : BaseViewModel
    {
        public Sponsorship Sponsorship { get; set; }

        public string RunnerString { get; set; }

        public SponsorshipConfirmationPageViewModel(Sponsorship sponsorship)
        {
            Sponsorship = sponsorship;
            RunnerString = $"{Sponsorship.Registration.RunnerFullName} " + 
                           $"({Sponsorship.Registration.BibNumber}) из " + 
                           $"{Sponsorship.Registration.Runner.Country.CountryName}";
        }
    }
}
