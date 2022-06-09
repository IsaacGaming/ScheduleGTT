namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disciplines
    {
        public Disciplines()
        {
            ScheduleLessons = new HashSet<ScheduleLessons>();
            Teachers = new HashSet<Teachers>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ShortName { get; set; }

        public virtual ICollection<ScheduleLessons> ScheduleLessons { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }


    }
}
