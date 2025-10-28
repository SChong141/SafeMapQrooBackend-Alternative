using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SafeMapQROO.Interface;
using SafeMapQROO.Models;

namespace SafeMapQROO.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;


        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }
        public async Task<AppUser?> DeleteUserAsync(string id)
        {
            var Exist = await _userManager.FindByIdAsync(id);
            if (Exist == null) return null;
            var Delite = await _userManager.DeleteAsync(Exist);
            if (Delite.Succeeded)
            {
                return Exist;
            }
            return null;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser?> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<AppUser?> UpdateUserAcync(string id, AppUser user)
        {
            var Exist = await _userManager.FindByIdAsync(id);
            if (Exist == null) return null;
            Exist.Names = user.Names;
            Exist.Lastname = user.Lastname;
            Exist.UserName = user.UserName;
            await _userManager.UpdateAsync(Exist);
            return Exist;
        }
    }
}