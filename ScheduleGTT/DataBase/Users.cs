using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleGTT.DataBase
{
    public partial class Users
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Login { get; set; }

        [StringLength(200)]
        public string Password { get; set; }
        
        public int? UserRole { get; set; }

        public virtual UserRoles UserRoles { get; set; }
    }
}
