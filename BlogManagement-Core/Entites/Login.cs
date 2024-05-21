using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Entites
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginIn { get; set; }
        public bool IsLoggedIn { get; set; }
        public int  UserId { get; set; }
    }
}
