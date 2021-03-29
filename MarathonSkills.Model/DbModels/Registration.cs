using System.Linq;

namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Registration")]
    public partial class Registration
    {
        public Registration()
        {
            RegistrationEvents = new HashSet<RegistrationEvent>();
            Sponsorships = new HashSet<Sponsorship>();
        }

        public int RegistrationId { get; set; }
        public int RunnerId { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string RaceKitOptionId { get; set; }
        public byte RegistrationStatusId { get; set; }
        public decimal Cost { get; set; }
        public int CharityId { get; set; }
        public decimal SponsorshipTarget { get; set; }

        public virtual Charity Charity { get; set; }
        public virtual RaceKitOption RaceKitOption { get; set; }
        public virtual RegistrationStatus RegistrationStatus { get; set; }
        public virtual Runner Runner { get; set; }
        public virtual ICollection<RegistrationEvent> RegistrationEvents { get; set; }
        public virtual ICollection<Sponsorship> Sponsorships { get; set; }

        [NotMapped] public string RunnerFullName => $"{Runner.User.FirstName} {Runner.User.LastName}";

        [NotMapped]
        public short? BibNumber
        {
            get
            {
                var registrationEvent = RegistrationEvents.First();
                return registrationEvent.BibNumber;
            }
        }

        [NotMapped]
        public string CountryCode => Runner.CountryCode;

        public override string ToString()
        {
            return $"{RunnerFullName} - {BibNumber} ({CountryCode})";
        }
    }
}
