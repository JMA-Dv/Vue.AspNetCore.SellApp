using Microsoft.AspNetCore.Identity;
using Model.DTOs;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public interface IUserService
    {
        Task Register(ApplicationUserRegisterDto model);
        Task Login(ApplicationUserLoginDto user);
    }
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public Task Login(ApplicationUserLoginDto user)
        {
            throw new NotImplementedException();
        }

        public Task Register(ApplicationUserRegisterDto model)
        {
            throw new NotImplementedException();
        }
    }
}
