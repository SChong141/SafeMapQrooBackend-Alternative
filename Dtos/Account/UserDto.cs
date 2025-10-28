using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos.Account
{
    public class UserDto
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string? Names { get; set; }
        public string? Lastname { get; set; }
    }
}