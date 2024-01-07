using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.Helper;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {


        private readonly MahaanidhieximContext _Authcontext;
        //private readonly IConfiguration _configuration;
        //private readonly UtilityServices.IEmailService _emailService;
        public RegisterController(MahaanidhieximContext context,
            IConfiguration configuration)
        //, UtilityServices.IEmailService emailService
        {
            _Authcontext = context;
            //_configuration = configuration;
            //_emailService = emailService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] RegisterDto UserObj)
        {
            if (UserObj == null)
                return BadRequest(new { Message = "Details not Found" });

            var User = await _Authcontext.Registers.FirstOrDefaultAsync(x => x.UserName == UserObj.UserName);

            if (User == null)
            {
                return NotFound(new { Message = "User Not Found" });
            }

            // Verify the password using a PasswordHasher or other method
            if (!PasswordHasher.VerifyPassword(UserObj.Password, User.Password))
            {
                return Unauthorized(new { Message = "Invalid Password" });
            }

            // Password is valid, create a token and return it
            User.Token = CreateJwt(User);
            return Ok(new
            {
                token = User.Token,
                registerDetails=User,
                Message = "Login Success!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto1 UserObj)
        {
            if (UserObj == null)
            {
                return BadRequest();
            }
            var customentity = new Register
            {
                Password = PasswordHasher.HashPassword(UserObj.Password),
                Role = UserObj.Role,
                Token = "",
                UserName = UserObj.UserName,
                FirstName = UserObj.FirstName,
                LastName = UserObj.LastName,
                MiddleName = UserObj.MiddleName,
                Address = UserObj.Address,
                Email = UserObj.Email,
                MobileNumber = UserObj.MobileNumber,
            };


            await _Authcontext.Registers.AddAsync(customentity);
            await _Authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered!"
            });
        }



        private string CreateJwt(Register user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");
            var identity = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Name,$"{user.FirstName}{user.LastName}")
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        [HttpGet]
        public IEnumerable<Register> GetAllUsers()
        {
            return _Authcontext.Registers.ToList();
        }
    }
}
