namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("RaceKitOption")]
    public partial class RaceKitOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceKitOption()
        {
            Registrations = new HashSet<Registration>();
        }

        [StringLength(1)]
        public string RaceKitOptionId { get; set; }

        [Column("RaceKitOption")]
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }

        public string NameLocalized => RaceKitOptionId switch
        {
            "A" => "����� ������+ RFID �������.",
            "B" => "������� A + ��������� + ������� ����",
            "C" => "������� B +�������� + ���������� ������.",
            _ => ""
        };

        public string FullNameLocalized => $"������� {RaceKitOptionId} (${Cost:N0}): {NameLocalized}";  
    }
}
