using CheckLib;
using MarathonSkills.Context;
using MarathonSkills.DesktopApp.Extensions;
using MarathonSkills.Model.DbModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarathonSkills.DesktopApp.ViewModels.PagesViewModels
{
    public class RegisterForEventPageViewModel : BaseViewModel
    {
        public ObservableCollection<Checkable<EventType>> CheckableEventTypes { get; set; } = new();

        public ObservableCollection<Checkable<RaceKitOption>> CheckableRaceKitOptions { get; set; } = new();

        public RegisterForEventPageViewModel()
        {
            LoadData();
        }

        private static async Task FillCollectionAsync<T>(DbSet<T> from, ObservableCollection<Checkable<T>> to, SynchronizationContext syncContext) where T : class
        {
            await from.ForEachAsync(x =>
            {
                var checkableItem = new Checkable<T>(x);
                syncContext.Invoke(() =>
                {
                    to.Add(checkableItem);
                });
            });
        }

        private async void LoadData()
        {
            using var db = new AppDbContext();
            await FillCollectionAsync(db.EventTypes, CheckableEventTypes, SynchronizationContext.Current);
            await FillCollectionAsync(db.RaceKitOptions, CheckableRaceKitOptions, SynchronizationContext.Current);

            CheckableRaceKitOptions.First().IsChecked = true;
        }
    }
}
