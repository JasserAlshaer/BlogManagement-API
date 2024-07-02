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
        public UserRepos(BlogsDbContext context)
        {
            _blogsDbContext = context;
        }

        public async Task<int> CreateBlog(Blog blog)
        {
            _blogsDbContext.Blogs.Add(blog);
            await _blogsDbContext.SaveChangesAsync();
            return blog.Id;
        }
        public async Task<User> GetUserById(int Id)
        {
            return await _blogsDbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Subscribtion> GetSubscrtiptionById(int Id)
        {
            return await _blogsDbContext.Subscribtions.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<Blog> GetBlogById(int Id)
        {
            return await _blogsDbContext.Blogs.FirstOrDefaultAsync(x => x.Id == Id);
        }


        public async Task<int> InsertSubscribationAndGetId(UserSubscription input)
        {
            await _blogsDbContext.AddAsync(input);
            await _blogsDbContext.SaveChangesAsync();
            return input.Id;
        }
        public async Task UpdateEntity<T>(T input)
        {
            _blogsDbContext.Update(input);
            await _blogsDbContext.SaveChangesAsync();
        }
        public async Task RemoveEntity<T>(T input)
        {
            _blogsDbContext.Remove(input);
            await _blogsDbContext.SaveChangesAsync();
        }

        public async Task<BlogDetailsDTO> GetBlogDetails(int Id)
        {
            var query = from blog in _blogsDbContext.Blogs
                        where blog.Id == Id
                        select new BlogDetailsDTO
                        {
                            Id = blog.Id,
                            Title = blog.Title,
                            ImagePath = blog.ImagePath,
                            Author = blog.Author,
                            CreationTime = blog.CreationTime,
                            Article = blog.Article,
                            IsActive = blog.IsActive,
                            IsApproved = blog.IsApproved,
                            UserId = blog.UserId
                        };
            return await query.SingleOrDefaultAsync();
        }

        public async Task<PaymentMethod> IsValidPayment(string code, string cardNumber, string cardHolder, float Price)
        {
            var payment = await _blogsDbContext.PaymentMethods.FirstOrDefaultAsync
                (x => x.Balance >= Price && x.CardHolder.Equals(cardHolder)
                && x.CardNumber.Equals(cardNumber) && x.Code.Equals(code));
            return payment;
        }
    }
}
