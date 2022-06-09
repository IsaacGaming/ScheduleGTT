namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LessonTypes
    {
        public LessonTypes()
        {
            ScheduleLessons = new HashSet<ScheduleLessons>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<ScheduleLessons> ScheduleLessons { get; set; }
    }
}
