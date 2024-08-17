﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.DTOs.Blogs
{
    public class BlogUserDTO
    {
        public int    Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
