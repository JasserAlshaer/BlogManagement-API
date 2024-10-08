﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.DTOs.Blogs
{
    public class BlogCardDTO
    {
        public int    Id         { get; set; }
        public string Title      { get; set; }
        public string Image      { get; set; }
        public string CreateDate { get; set; }
        public string Author      { get; set; }
        public int AuthorId { get; set; }
    }
}
