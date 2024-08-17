using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.DTOs.Blogs
{
    public class CreateBlogDTO
    {
        public string Title     { get; set; }
        public string Article    { get; set; }
        public string ImagePath  { get; set; }
        public int    UserId    { get; set; }
    }
}
