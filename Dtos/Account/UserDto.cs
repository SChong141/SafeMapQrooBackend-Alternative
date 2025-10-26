using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos.Account
{
    public class UserDto
    {
        public string? Email { get; set; }

        public string? Curp { get; set; }
        public string? Names { get; set; }
        public string? Lastname { get; set; }
    }
}