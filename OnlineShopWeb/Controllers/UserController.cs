using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWeb.Db;
using OnlineShopWeb.JWT;
using System;
using System.Linq;
using System.Security.Claims;

namespace OnlineShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext context;
        private readonly IJwtAuthManager jwtAuthManager;

        public UserController(MyDbContext context, IJwtAuthManager jwtAuthManager)
        {
            this.context = context;
            this.jwtAuthManager = jwtAuthManager;
        }

        [HttpGet("login")]
        public LoginResult Login(string username, string password)
        {
            var user = context.Employees
                .FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
                return null;
            var claims = new Claim[] { new Claim(ClaimTypes.Name, username) };
            var tokens = jwtAuthManager.GenerateTokens(username, claims, DateTime.Now);
            return new LoginResult
            {
                User = user,
                AccessToken = tokens.AccessToken
            };
        }
    }

    public class LoginResult
    {
        public Employee User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
