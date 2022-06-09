namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScheduleLessons
    {
        public int Id { get; set; }

        public DateTime? DateLesson { get; set; }

        public int? Discipline { get; set; }

        public int? Teacher { get; set; }

        public int? LessonType { get; set; }

        public int? GroupId { get; set; }

        public int? ScheduleBell { get; set; }

        public int? Room { get; set; }

        public virtual Disciplines Disciplines { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual LessonTypes LessonTypes { get; set; }

        public virtual Rooms Rooms { get; set; }

        public virtual ScheduleBell ScheduleBell1 { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
