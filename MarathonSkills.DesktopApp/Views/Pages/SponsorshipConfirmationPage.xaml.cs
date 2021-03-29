using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MarathonSkills.DesktopApp.ViewModels.PagesViewModels;
using MarathonSkills.Model.DbModels;

namespace MarathonSkills.DesktopApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для SponsorshipConfirmationPage.xaml
    /// </summary>
    public partial class SponsorshipConfirmationPage : Page
    {
        public SponsorshipConfirmationPage(Sponsorship sponsorship)
        {
            InitializeComponent();
            DataContext = new SponsorshipConfirmationPageViewModel(sponsorship);
        }
    }
}
