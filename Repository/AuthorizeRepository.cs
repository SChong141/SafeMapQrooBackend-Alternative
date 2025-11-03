using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SafeMapQROOBackend.Dtos.Account;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Repository
{
    public class AuthorizeRepository : IAuthorizeRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AuthorizeRepository(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<NewLoginDTO?> RegisterNewUserAsyn(AppUser registerNew, string role, string password)
        {
            var createUser = await _userManager.CreateAsync(registerNew, password);
            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(registerNew, role);
                if (roleResult.Succeeded)
                {
                    return new NewLoginDTO
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

            if (ExistUser == null)
            {
                return null;
            }

            var removeResult = await _userManager.RemovePasswordAsync(ExistUser);

            if (!removeResult.Succeeded)
            {
                return null;
            }

            var Resultpass = await _userManager.AddPasswordAsync(ExistUser, newPassword);

            if (!Resultpass.Succeeded)
            {
                return null;
            }
            
            return ExistUser;
        }

        /*public List<string> GetRolAsync(string token)
        {
            var Hander = new JwtSecurityTokenHandler();

            var jwtToken = Hander.ReadJwtToken(token);

            return jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role || c.Type == "role")
            .Select(c => c.Value)
            .ToList();
        }*/
    }
}