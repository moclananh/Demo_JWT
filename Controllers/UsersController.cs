using JWT_Demo.EF;
using JWT_Demo.Models;
using JWT_Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly AppSetting _app;

        public UsersController(AppDbContext dbContext, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _dbContext = dbContext;
            _app = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public IActionResult Authentication(LoginVM request)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == request.Email 
            && x.Password == request.Password);

            if (user == null) {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Email or password incorrect!"
                });
            }

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Login Success!",
                Data = GenerateToken(user)
            });
        }

        private string GenerateToken(Users user){
            var jwtTokenHandel = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_app.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                   
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), 
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandel.CreateToken(tokenDescription);
            return jwtTokenHandel.WriteToken(token);
        }
    }
}
