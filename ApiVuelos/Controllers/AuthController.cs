using ApiVuelos.Context;
using ApiVuelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ApiVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IConfiguration configuration;

        public AuthController(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> login([FromBody] UserLoginDTO dataLogin)
        {
            var user = context.usuarios.SingleOrDefault(x => x.UserName == dataLogin.UserName);

            if(user == null|| !BCryptNet.Verify(dataLogin.Password, user.Password))
                return NotFound("Username or password are incorrect");

            var secretKey = configuration.GetValue<string>("secretKey");
            var key = Encoding.UTF8.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, dataLogin.UserName));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            string bearerToken = tokenHandler.WriteToken(createdToken);

            user.Token= bearerToken;
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return bearerToken;
        }
    }
}
