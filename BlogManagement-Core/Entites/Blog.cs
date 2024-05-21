using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Entites
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }  
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
    }
}
