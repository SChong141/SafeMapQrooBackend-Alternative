using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROO.Models;

namespace SafeMapQROO.Interface
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}