using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}