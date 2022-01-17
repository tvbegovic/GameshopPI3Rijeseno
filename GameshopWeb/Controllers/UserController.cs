using GameshopWeb.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private MyDbContext context;
        public UserController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet("login")]
        public LoginResult Login(string email, string password)
        {
            var user = context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
                return null;
            return new LoginResult
            {
                User = user
            };
        }
    }

    public class LoginResult
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
