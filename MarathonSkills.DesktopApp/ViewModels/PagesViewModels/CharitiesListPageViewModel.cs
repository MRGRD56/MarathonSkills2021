using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarathonSkills.Context;
using MarathonSkills.DesktopApp.Extensions;
using MarathonSkills.Model.DbModels;

namespace MarathonSkills.DesktopApp.ViewModels.PagesViewModels
{
    public class CharitiesListPageViewModel : BaseViewModel
    {
        public ObservableCollection<Charity> Charities { get; set; } = new();

        public CharitiesListPageViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            var synchronizationContext = SynchronizationContext.Current;
            using var db = new AppDbContext();
            await db.Charities.ForEachAsync(x =>
            {
                synchronizationContext.Invoke(() => Charities.Add(x));
            });
        }
    }
}
