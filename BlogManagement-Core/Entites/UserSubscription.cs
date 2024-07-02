using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Entites
{
    public class UserSubscription
    {
        public int Id { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual User User { get; set; }  
        public virtual Subscribtion Subscribtion { get; set; }
    }
}
