using BlogManagement_Core.DTOs.Authantication;
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
    }
}
