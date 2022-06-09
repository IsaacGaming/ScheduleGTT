namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Groups
    {
        public Groups()
        {
            ScheduleLessons = new HashSet<ScheduleLessons>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? Speciality { get; set; }

        public int? GroupType { get; set; }

        public virtual ICollection<ScheduleLessons> ScheduleLessons { get; set; }

        public virtual GroupTypes GroupTypes { get; set; }

        public virtual Specialities Specialities { get; set; }
    }
}
