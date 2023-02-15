using DemoJwtApi.Infra.Domain;
using DemoJwtApi.Infra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoJwtApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController: ControllerBase
    {
        public IConfiguration _configuration;
        private readonly EmployeeContext _employeeContext;

        public TokenController(IConfiguration configuration,EmployeeContext employeeContext)
        {
            _configuration = configuration;
            _employeeContext = employeeContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo userInfo)
        {
            if (userInfo != null && userInfo.Email != null && userInfo.Password != null)
            {
                var user = await GetUser(userInfo.Email, userInfo.Password);

                if (user != null)
                {
                    var claims = new[]
                    {
                        //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email", user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        private async Task<UserInfo> GetUser(string email, string password)
        {
            return await _employeeContext.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password==password);

        }
    }
}
