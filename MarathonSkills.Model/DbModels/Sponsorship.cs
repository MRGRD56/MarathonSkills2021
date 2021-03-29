namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Sponsorship")]
    public partial class Sponsorship : BaseModel
    {
        private Registration _registration;
        private decimal _amount;
        private string _sponsorName;
        public int SponsorshipId { get; set; }

        public string SponsorName
        {
            get => _sponsorName;
            set
            {
                if (value == _sponsorName) return;
                _sponsorName = value;
                OnPropertyChanged();
            }
        }

        public int RegistrationId { get; set; }

        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value == _amount || value < 0) return;
                _amount = value;
                OnPropertyChanged();
            }
        }

        public virtual Registration Registration
        {
            get => _registration;
            set
            {
                if (Equals(value, _registration)) return;
                _registration = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsRunnerSelected));
            }
        }

        public bool IsRunnerSelected => Registration != null;
    }
}
