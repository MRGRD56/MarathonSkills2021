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
using System.Windows.Shapes;
using MarathonSkills.DesktopApp.ViewModels.WindowsViewModels;
using MarathonSkills.Model.DbModels;

namespace MarathonSkills.DesktopApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CharityInfoWindow.xaml
    /// </summary>
    public partial class CharityInfoWindow : Window
    {
        public CharityInfoWindow(Charity charity)
        {
            InitializeComponent();
            DataContext = new CharityInfoWindowViewModel(charity);
        }
    }
}
