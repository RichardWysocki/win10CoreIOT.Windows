using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ASPNETCore.Docker.Model;

namespace Services.ASPNETCore.Docker.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _config;

            public TokenController(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            {
                _config = config;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [AllowAnonymous]
            [HttpPost]
            public IActionResult CreateToken([FromBody]LoginModel login)
            {
                IActionResult response = Unauthorized();
                var user = Authenticate(login);

                if (user != null)
                {
                    var tokenString = BuildToken(user);
                    response = Ok(new { token = tokenString });
                }

                return response;
            }

        private string BuildToken(UserModel user)
        {

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            private UserModel Authenticate(LoginModel login)
            {
                var userx = _userManager.FindByEmailAsync("RichardWysocki@gmail.com").Result;
                //var user = new ApplicationUser() { UserName = "Richard" };
                var result = _signInManager.CheckPasswordSignInAsync(userx, "Test1234$", false).Result;

            UserModel user = null;

            if (login.Username == "mario" && login.Password == "secret")
            {
                user = new UserModel { Name = "Mario Rossi", Email = "mario.rossi@domain.com", Birthdate = new DateTime(1983, 9, 23)};
            }

            if (login.Username == "mary" && login.Password == "barbie")
            {
                user = new UserModel { Name = "Mary Smith", Email = "mary.smith@domain.com", Birthdate = new DateTime(2001, 5, 13) };
            }

            return user;

        }

            public class LoginModel
            {
                public string Username { get; set; }
                public string Password { get; set; }
            }

            private class UserModel
            {
                public string Name { get; set; }
                public string Email { get; set; }
                public DateTime Birthdate { get; set; }
            }
        }

    }
