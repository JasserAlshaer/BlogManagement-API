using BlogManagement_Core.DTOs.Authantication;
using BlogManagement_Core.DTOs.Blogs;
using BlogManagement_Core.Entites;
using BlogManagement_Core.IRepos;
using BlogManagement_Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepos _repository;
        public UserService(IUserRepos repository)
        {
            _repository = repository;
        }

        public async Task CreateNewBlog(CreateBlogDTO input)
        {
            var user = await _repository.GetUserById(input.UserId);
            if (user != null)
            {
                Blog blog = new Blog();
                blog.Title = input.Title;
                blog.Article = input.Article;
                blog.Author = user.Name;
                blog.ImagePath = input.ImagePath;
                blog.UserId = user.Id;

                var id = await _repository.CreateBlog(blog);
                if (id == 0)
                    throw new Exception("Failed To Create Blog See Inner Log For Details");
            }
            else
                throw new Exception("User Dose not Exisit");

        }

        public async Task DeletBlog(int Id)
        {
            //check if exisit 
            var blog = await _repository.GetBlogById(Id);
            if (blog != null)
            {
                await _repository.RemoveEntity(blog);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task<BlogDetailsDTO> GetBlogDetailsByIdInMemoryExecution(int Id)
        {
            //check if exisit 
            var blog = await _repository.GetBlogById(Id);
            if (blog != null)
            {
                BlogDetailsDTO blogDetails = new BlogDetailsDTO();
                blogDetails.Title = blog.Title;
                blogDetails.Article = blog.Article;
                blogDetails.Author = blog.Author;
                blogDetails.ImagePath = blog.ImagePath; 
                blogDetails.UserId = blog.UserId;
                blogDetails.Id=blog.Id;
                blogDetails.CreationTime = blog.CreationTime;
                blogDetails.IsActive = blog.IsActive;
                blogDetails.IsApproved = blog.IsApproved;
                if (string.IsNullOrEmpty(blogDetails.ImagePath))
                {
                    blogDetails.ImagePath = "https://www.shutterstock.com/image-vector/concept-blogging-golden-blog-word-260nw-755744683.jpg";
                }
                return blogDetails;
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }
        public async Task<BlogDetailsDTO> GetBlogDetailsByIdInQuerable(int Id)
        {
            //check if exisit 
            var blog = await _repository.GetBlogById(Id);
            if (blog != null)
            {
                return await _repository.GetBlogDetails(Id);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task<List<BlogCardDTO>> GetBlogs()
        {
            var entites = await _repository.GetBlogsEntity();
            List<BlogCardDTO> blogCards = new List<BlogCardDTO>();
            foreach (var blog in entites)
            {
                blogCards.Add(new BlogCardDTO()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Image = blog.ImagePath,
                    Author = blog.Author,
                    CreateDate = blog.CreationTime.ToString()
                });
            }
            return blogCards;
        }

        public async Task<List<BlogCardDTO>> GetBlogsByRepos()
        {
            return await _repository.GetBlogsDTOsDirect();
        }

        public async Task RegisterNewClient(RegistrationDTO input)
        {
            //setup for entities 
            User user = new User()
            {
                Email = input.Email,
                JoinDate = DateTime.Now,
                Phone = input.Phone,
                Name = input.Name,
            };
            //move to repos
            int entityId = await _repository.CreateUserAndGetId(user);
            Login login = new Login()
            {
                Username = input.Email,
                Password = input.Password,
                UserId = entityId
            };
            //move to repos
            await _repository.CreateLogin(login);
        }

        public async Task UpdateBlog(UpdateBlogDTO input)
        {
            //check if exisit 
            var blog = await _repository.GetBlogById(input.Id);
            if (blog != null)
            {
                if (input.Article != null && !input.Article.Equals(""))
                {
                    blog.Article = input.Article;
                }
                if (!string.IsNullOrEmpty(input.Title))
                {
                    blog.Title = input.Title;
                }
                if (!string.IsNullOrEmpty(input.ImagePath))
                {
                    blog.ImagePath = input.ImagePath;
                }
                await _repository.UpdateEntity(blog);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task UpdateBlogActivation(int Id, bool value)
        {
            var blog = await _repository.GetBlogById(Id);
            if (blog != null)
            {
                blog.IsActive = value;
                await _repository.UpdateEntity(blog);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task UpdateBlogApprovment(int Id, bool value)
        {
            var blog = await _repository.GetBlogById(Id);
            if (blog != null)
            {
                blog.IsApproved = value;
                await _repository.UpdateEntity(blog);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }
    }
}
