namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("EventType")]
    public partial class EventType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        [StringLength(2)]
        public string EventTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        public string EventTypeNameLocalized
        {
            get
            {
                return EventTypeId switch
                {
                    "FM" => "42km Полный марафон ($145)",
                    "FR" => "21km Полу марафон ($75)",
                    "HM" => "5km Малая дистанция ($20)",
                    _ => ""
                };
            }
        }
    }
}
