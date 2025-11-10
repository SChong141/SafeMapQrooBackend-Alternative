using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROOBackend.Dtos.Account;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Interfaces
{
    public interface IAuthorizeRepository
    {
        Task<NewLoginDTO?> RegisterNewUserAsync(AppUser registerNew, string role, string password);
        Task<AppUser?> NewPasswordAsync(string Email, string password);
    }
}