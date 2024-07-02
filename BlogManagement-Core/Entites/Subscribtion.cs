using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Entites
{
    public class Subscribtion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInDay { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
