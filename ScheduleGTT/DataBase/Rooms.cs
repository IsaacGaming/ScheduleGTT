namespace ScheduleGTT.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rooms
    {
        public Rooms()
        {
            ScheduleLessons = new HashSet<ScheduleLessons>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string NumberRoom { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public string FullNameRoom => $"({NumberRoom.Trim()}) {Name}";

        public virtual ICollection<ScheduleLessons> ScheduleLessons { get; set; }
    }
}
