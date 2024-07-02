using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; } 
        public string Key { get; set; }
        public string Iv { get; set; }
        public virtual ICollection<UserSubscription>UserSubscriptions { get; set; } 
    }
}
