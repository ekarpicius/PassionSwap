using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PassionSwap.Models;
using PassionSwap.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PassionSwap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, IUserRepository userRepository, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationModel registration)
        {
            var existingUser = _userRepository.GetUserByEmail(registration.Email);
            if (existingUser != null)
            {
                return BadRequest("Email already registered");
            }

            var newUser = new User
            {
                Name = registration.Name,
                Email = registration.Email,
                Password = registration.Password,
                // ideally obv hash
            };

            _userRepository.AddUser(newUser);
            _logger.LogInformation($"New user {newUser.Email} registered");

            return Ok();
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = _userRepository.GetUserByEmail(login.Email);
            // more complex password validation would go below
            if (user == null || login.Password != user.Password)
            {
                return Unauthorized("Invalid email or password");
            }

            var token = GenerateToken(user.Id);
            _logger.LogInformation($"User {user.Email} logged in");

            return Ok(new { token });
        }


        private string GenerateToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                },
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
