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
        Task<AppUser?> GetByIdAsync(string id);
        Task<AppUser?> UpdateUserAcync(string id, AppUser user);
        Task<AppUser?> DeleteUserAsync(string id);



    }

}