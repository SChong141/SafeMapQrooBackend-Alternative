using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROO.Dtos;
using SafeMapQROO.Dtos.Account;
using SafeMapQROO.Models;

namespace SafeMapQROO.Interface
{
    public interface IRegisterRepository
    {
        Task<InfoUserDto?> RegisterNewUserAsyn(AppUser registerNew, string role, string password);
        Task<AppUser?> NewPasswordAsync(string Email, string password);
    }
}