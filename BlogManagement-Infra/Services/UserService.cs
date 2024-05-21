using BlogManagement_Core.DTOs.Authantication;
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
        public async Task RegisterNewClient(RegistrationDTO input)
        {
           //setup for entities 
           User user = new User()
           {
               Email = input.Email,
               JoinDate=DateTime.Now,
               Phone=input.Phone,
               Name=input.Name,
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
    }
}
