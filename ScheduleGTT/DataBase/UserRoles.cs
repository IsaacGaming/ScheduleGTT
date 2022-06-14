using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleGTT.DataBase
{
    public partial class UserRoles
    {
        public UserRoles()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        
        public ICollection<Users> Users { get; set; }
    }
}
