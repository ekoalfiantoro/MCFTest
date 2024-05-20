using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IConfiguration _configuration;

        public SessionController(ISessionService _sessionService, IConfiguration _configuration)
        {
            this._sessionService = _sessionService;
            this._configuration = _configuration;
        }

        [HttpPost]
        [Authorize] 
        [Route("GetUser")]
        [Produces("application/json")]
        public async Task<IActionResult> GetListUser()
        {
            try
            {
                var listMsUser = await _sessionService.GetUser();
                return Ok(listMsUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {

                bool isValid = await _sessionService.ValidateUser(model.Username, model.Password);
                if (isValid)
                {
                    var token = GenerateJwtToken(model.Username);
                    return Ok(new { token });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiresInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
