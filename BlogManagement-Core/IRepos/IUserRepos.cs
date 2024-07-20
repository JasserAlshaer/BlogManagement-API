using BlogManagement_Core.DTOs.Blogs;
using BlogManagement_Core.DTOs.Subscription;
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
        Task<int> GetUserIdAfterLoginOperation(string email, string password);
        Task RemoveEntity<T>(T input);
        Task UpdateEntity<T>(T input);
        Task<List<SubscribtionDTO>> GetSubscribtions();
        Task<int> InsertSubscribationAndGetId(UserSubscription input);
        Task<Blog> GetBlogById(int Id);
        Task<User> GetUserById(int Id);
        Task<Subscribtion> GetSubscrtiptionById(int Id);
        Task<PaymentMethod> IsValidPayment(string code, string cardNumber, string cardHolder, float Price);
        Task<int> CreateBlog(Blog blog);
        Task<int> CreateUserAndGetId(User input);
        Task CreateLogin(Login input);
        //get ALL
        Task<BlogDetailsDTO> GetBlogDetails(int Id);
        Task<List<Blog>> GetBlogsEntity();
        Task<List<BlogCardDTO>> GetBlogsDTOsDirect();
    }
}
