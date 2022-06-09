namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScheduleBell")]
    public partial class ScheduleBell
    {
        public ScheduleBell()
        {
            ScheduleLessons = new HashSet<ScheduleLessons>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public DateTime? BeginBell { get; set; }

        public DateTime? EndBell { get; set; }

        public virtual ICollection<ScheduleLessons> ScheduleLessons { get; set; }
    }
}
