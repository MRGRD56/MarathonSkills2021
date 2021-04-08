using System.ComponentModel;

namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Runner")]
    public partial class Runner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Runner()
        {
            Registrations = new HashSet<Registration>();
        }

        public int RunnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        [Column("Gender")]
        public string GenderCode { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Age
        {
            get
            {
                if (!DateOfBirth.HasValue) return null;
                var birthDate = DateOfBirth.Value is { Day: 29, Month: 2 } //C# 9
                    ? DateOfBirth.Value.AddDays(1)
                    : DateOfBirth.Value;

                var age = -1;
                for (var date = birthDate; date <= DateTime.Today; date = date.AddDays(1))
                {
                    if (date.Day == birthDate.Day && date.Month == birthDate.Month)
                    {
                        age++;
                    }
                }

                return age;
            }
        }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        public virtual Country Country { get; set; }

        [ForeignKey("Gender")]
        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }

        public virtual User User { get; set; }
    }
}
