using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PsicopataPedidos.Application;
using PsicopataPedidos.Application.Dtos;
using PsicopataPedidos.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PsicopataPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _service;
        private readonly IHttpContextAccessor _accesor;

        public AuthController(IConfiguration configuration, IUserService service, IHttpContextAccessor accessor)
        {
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
             CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            
            user.Name = request.Name;
            user.Password = request.Password;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            PostUser(user);

            return Ok(user);
        } 
   
        private User PostUser(User user)
        {

            var userFromService = _service.CreateUser(user);
            return userFromService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(User request)
        {
            var userFind = _service.GetAllUsers().Where(x => x.Name == request.Name && x.Password == request.Password).FirstOrDefault();
            if (userFind is null)
            {
                return BadRequest("User not found.");
            }

            string token = CreateToken(userFind);

            return Ok(token);


        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentUser ()
        {
            var result = await GetCurrentADUser();
            return Ok(result);
        }

        private async Task<UserAD> GetCurrentADUser()
        {
            if (_accesor.HttpContext is null) return null;
            var adUser = new UserAD
            {
                Id = _accesor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value,
                Name = _accesor.HttpContext.User.Claims.FirstOrDefault(x => x.Type ==
               "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value,
                Email = _accesor.HttpContext.User.Claims.FirstOrDefault(x => x.Value ==
               "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/preferred_username")?.Value,
                TenantId = _accesor.HttpContext.User.Claims.FirstOrDefault(x => x.Type
               == "http://schemas.microsoft.com/identity/claims/tenantid")?.Value
            };
            return adUser;
        }
    }
}
