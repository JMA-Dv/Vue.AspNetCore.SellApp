using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUserRegisterDto model)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
            }, model.Password);


            if (!result.Succeeded)
            {
                throw new Exception("Could not Create user");
            }
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(ApplicationUserLoginDto model)
        {
            var userByEmail = await _userManager.FindByEmailAsync(model.Email);
            var check =  await _signInManager.CheckPasswordSignInAsync(userByEmail, model.Password, false);

            if (!check.Succeeded)
            {
                return BadRequest("email or password must be wrong!");
            }

            return Ok(
                GenerateToken(userByEmail));

        }

        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = _configuration.GetValue<string>("SecretKey");
            //transform it to bit

            var key = Encoding.ASCII.GetBytes(securityKey);

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name,user.FirstName),
                    new Claim(ClaimTypes.Surname,user.LastName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
