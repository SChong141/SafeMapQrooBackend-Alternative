using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos.Account
{
    public class InfoUserDto
    {
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}