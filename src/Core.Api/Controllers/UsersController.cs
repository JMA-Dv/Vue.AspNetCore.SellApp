using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create(ApplicationUserRegisterDto model)
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
    }
}
