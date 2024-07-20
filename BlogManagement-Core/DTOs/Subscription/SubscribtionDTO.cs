using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.DTOs.Subscription
{
    public class SubscribtionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInDay { get; set; }
        public float Price { get; set; }
    }
}
