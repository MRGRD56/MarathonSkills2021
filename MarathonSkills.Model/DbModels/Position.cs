namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Positions")]
    public partial class Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            Staffs = new HashSet<Staff>();
        }

        public int PositionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PositionName { get; set; }

        [StringLength(1000)]
        public string PositionDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string PayPeriod { get; set; }

        public decimal PayRate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
