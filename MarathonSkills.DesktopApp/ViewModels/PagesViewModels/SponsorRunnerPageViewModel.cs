using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MarathonSkills.Context;
using MarathonSkills.DesktopApp.Other;
using MarathonSkills.DesktopApp.ViewModels;
using MarathonSkills.Model.DbModels;
using MarathonSkills.DesktopApp.Views.Pages;

namespace MarathonSkills.DesktopApp.ViewModels.PagesViewModels
{
    public class SponsorRunnerPageViewModel : BaseViewModel
    {
        public Sponsorship NewSponsorship { get; set; }

        public ObservableCollection<Registration> Registrations { get; set; } = new();

        public Command IncrementAmount => new(o =>
        {
            NewSponsorship.Amount += 10;
        });

        public Command DecrementAmount => new(o =>
        {
            if (NewSponsorship.Amount >= 10)
            {
                NewSponsorship.Amount -= 10;
            }
            else
            {
                NewSponsorship.Amount = 0;
            }
        });

        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardDate { get; set; }
        public string CardCvc { get; set; }

        public Command PayCommand => new(o =>
        {
            if (string.IsNullOrWhiteSpace(NewSponsorship.SponsorName))
            {
                MessageBox.Show("Укажите имя спонсора.");
                return;
            }

            if (NewSponsorship.Registration == null)
            {
                MessageBox.Show("Выберите бегуна из выпадающего списка.");
                return;
            }

            if (CardCvc?.Length < 3 ||
                CardNumber?.Length < 16 ||
                string.IsNullOrWhiteSpace(CardOwner) ||
                CardDate.Equals(default))
            {
                MessageBox.Show("Указаны неверные данные карты.");
                return;
            }

            if (CardDate.AddMonths(1) < DateTime.Now)
            {
                MessageBox.Show("Указан недействительный срок действия карты.");
                return;
            }

            var db = new AppDbContext();

            NewSponsorship.Registration = db.Registrations.Find(NewSponsorship.Registration.RegistrationId);

            db.Sponsorships.Add(NewSponsorship);
            db.SaveChanges();

            Navigation.Navigate(new SponsorshipConfirmationPage(NewSponsorship));

        }, _ => NewSponsorship.Amount > 0);

        public SponsorRunnerPageViewModel()
        {
            NewSponsorship = new Sponsorship
            {
                Amount = 50
            };

            LoadData();
        }

        private async void LoadData()
        {
            var db = new AppDbContext();
            await db.RegistrationEvents.LoadAsync();
            await db.Users.LoadAsync();
            var registrations = db.Registrations
                .Include(x => x.Runner)
                .Include(x => x.Charity)
                .OrderBy(x => x.Runner.User.FirstName)
                .ThenBy(x => x.Runner.User.LastName);

            var syncContext = SynchronizationContext.Current;
            await registrations.ForEachAsync(x =>
            {
                syncContext.Send(_ =>
                {
                    Registrations.Add(x);
                }, null);
            });
        }
    }
}
