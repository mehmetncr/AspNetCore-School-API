using AspNetCore_School_DataAccess_Layer.Identity;
using AspNetCore_School_Entity_Layer.DTOs;
using AspNetCore_School_Entity_Layer.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            string msg = string.Empty;
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return "not found";
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false,false);
            if (result.Succeeded)
            {
                return user.UserName;
            }            
            return "wrong user";
        }

        public async Task<string> RegisterAsync(RegisterDto model)
        {
            string msg = string.Empty;
            AppUser user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return "Ok";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    msg = error.Description;
                }
            }
            return msg;
        }
    }
}
