using BlogManagement_Core.DTOs.Authantication;
using BlogManagement_Core.DTOs.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.IService
{
    public interface IUserService
    {
        Task RegisterNewClient(RegistrationDTO input);
        Task<List<BlogCardDTO>> GetBlogs();
        Task<List<BlogCardDTO>> GetBlogsByRepos();
    }
}
