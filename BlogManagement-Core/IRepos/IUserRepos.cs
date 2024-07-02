using BlogManagement_Core.DTOs.Blogs;
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
        Task RemoveEntity<T>(T input);
        Task UpdateEntity<T>(T input);
        Task<Blog> GetBlogById(int Id);
        Task<User> GetUserById(int Id);
        Task<int> CreateBlog(Blog blog);
        Task<int> CreateUserAndGetId(User input);
        Task CreateLogin(Login input);
        //get ALL
        Task<BlogDetailsDTO> GetBlogDetails(int Id);
        Task<List<Blog>> GetBlogsEntity();
        Task<List<BlogCardDTO>> GetBlogsDTOsDirect();
    }
}
