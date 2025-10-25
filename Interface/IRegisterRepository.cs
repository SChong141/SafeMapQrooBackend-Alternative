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
        Task<NewUserDto> RegisterNewUserAsyn(AppUser registerNew, string role, string password);
    }
}