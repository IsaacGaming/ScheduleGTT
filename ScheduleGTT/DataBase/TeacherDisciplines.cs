using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleGTT.DataBase
{
    public partial class TeacherDisciplines
    {
        [Key]
        [Column(Order = 1)]
        public int TeacherId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int DisciplineId { get; set; }

        [ForeignKey("TeacherId")]
        public Teachers Teachers { get; set; }

        [ForeignKey("DisciplineId")]
        public Disciplines Disciplines { get; set; }
    }
}
