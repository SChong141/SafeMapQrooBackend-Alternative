using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROO.Models;

namespace SafeMapQROO.Interface
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllUsersAsync();
        Task<AppUser?> GetByEmailAsync(string Email);
        Task<AppUser?> UpdateUserAcync(string Email, AppUser user);
        Task<AppUser?> DeleteUserAsync(string Email);



    }

}