using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafeMapQROO.Dtos;
using SafeMapQROO.Dtos.Account;
using SafeMapQROO.Interface;
using SafeMapQROO.Models;

namespace SafeMapQROO.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public RegisterRepository(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<InfoUserDto?> RegisterNewUserAsyn(AppUser registerNew, string role, string password)
        {
            var createUser = await _userManager.CreateAsync(registerNew, password);
            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(registerNew, role);
                if (roleResult.Succeeded)
                {
                    return new InfoUserDto
                    {
                        UserName = registerNew.UserName,
                        Email = registerNew.Email,
                        Token = await _tokenService.CreateToken(registerNew)
                    };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<AppUser?> NewPasswordAsync(string Email, string newPassword)
        {
            var ExistUser = await _userManager.FindByEmailAsync(Email);
            if (ExistUser == null) return null;
            var removeResult = await _userManager.RemovePasswordAsync(ExistUser);
            if (!removeResult.Succeeded) return null;
            var Resultpass = await _userManager.AddPasswordAsync(ExistUser, newPassword);
            if (!Resultpass.Succeeded) return null;
            return ExistUser;
        }
    }
}