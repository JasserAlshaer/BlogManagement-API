using BlogManagement_Core.Context;
using BlogManagement_Core.DTOs.Blogs;
using BlogManagement_Core.Entites;
using BlogManagement_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Infra.Repos
{
    public class UserRepos : IUserRepos
    {
        private readonly BlogsDbContext _blogsDbContext;
        public UserRepos(BlogsDbContext context) {
            _blogsDbContext = context;
        }
        public async Task CreateLogin(Login input)
        {
            _blogsDbContext.Logins.Add(input);
            await _blogsDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateUserAndGetId(User input)
        {
           _blogsDbContext.Users.Add(input);
           await _blogsDbContext.SaveChangesAsync();
           return input.Id;
        }

        public async Task<List<BlogCardDTO>> GetBlogsDTOsDirect()
        {
            var query = from blog in _blogsDbContext.Blogs
                        select new BlogCardDTO
                        {
                            Id = blog.Id,
                            Title = blog.Title,
                            Image = blog.ImagePath,
                            Author = blog.Author,
                            CreateDate = blog.CreationTime.ToString()
                        };
            return await query.ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsEntity()
        {
            return await _blogsDbContext.Blogs.ToListAsync();
        }
    }
}
