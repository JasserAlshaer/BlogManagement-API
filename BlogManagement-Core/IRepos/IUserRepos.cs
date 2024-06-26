﻿using BlogManagement_Core.DTOs.Blogs;
using BlogManagement_Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.IRepos
{
    public interface IUserRepos
    {
        Task<int> CreateUserAndGetId(User input);
        Task CreateLogin(Login input);
        //get ALL
        Task<List<Blog>> GetBlogsEntity();
        Task<List<BlogCardDTO>> GetBlogsDTOsDirect();
    }
}
