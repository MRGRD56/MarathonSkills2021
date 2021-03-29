namespace MarathonSkills.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Timesheets")]
    public partial class Timesheet
    {
        public int TimesheetId { get; set; }

        public int StaffId1 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }

        public decimal PayAmount { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
