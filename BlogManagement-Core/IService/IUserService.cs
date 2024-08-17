using BlogManagement_Core.DTOs.Authantication;
using BlogManagement_Core.DTOs.Blogs;
using BlogManagement_Core.DTOs.Subscription;
using BlogManagement_Core.DTOs.Users;
using BlogManagement_Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.IService
{
    public interface IUserService
    {
        Task<List<SubscribtionDTO>> GetSubscribtions();
        Task<string> GenerateUserAccessToken(AuthanticationDTO input);
        Task<User> TryAuthanticate(AuthanticationDTO input);
        Task<UserProfileDTO> GetUserProfileById(int Id);
        Task<BlogDetailsDTO> GetBlogDetailsByIdInQuerable(int Id);
        Task<BlogDetailsDTO> GetBlogDetailsByIdInMemoryExecution(int Id);
        Task<List<BlogUserDTO>> GetUserBlogByUserId(int Id);
        Task UpdateBlogApprovment(int Id, bool value);
        Task UpdateBlogActivation(int Id, bool value);
        Task UpdateBlog(UpdateBlogDTO input);
        Task CreateNewBlog(CreateBlogDTO input);
        Task DeletBlog(int Id);
        Task RegisterNewClient(RegistrationDTO input);
        Task<List<BlogCardDTO>> GetBlogs();
        Task<List<BlogCardDTO>> GetBlogsByRepos();
        Task SetNewSubscrubtion(CreateNewSubsucriptionDTO input);
    }
}
