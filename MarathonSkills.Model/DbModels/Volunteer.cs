namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Volunteer")]
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }

        [StringLength(80)]
        public string FirstName { get; set; }

        [StringLength(80)]
        public string LastName { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public virtual Country Country { get; set; }

        public virtual Gender GenderNav { get; set; }
    }
}
