namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teachers
    {
        public Teachers()
        {
            ScheduleLessons = new HashSet<ScheduleLessons>();
            Disciplines = new HashSet<Disciplines>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(200)]
        public string MiddleName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public virtual ICollection<ScheduleLessons> ScheduleLessons { get; set; }

        public virtual ICollection<Disciplines> Disciplines { get; set; }
    }
}
