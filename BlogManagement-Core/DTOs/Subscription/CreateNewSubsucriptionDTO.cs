using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.DTOs.Subscription
{
    public class CreateNewSubsucriptionDTO
    {
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
    }
}
