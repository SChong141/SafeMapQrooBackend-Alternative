using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos.Account
{
    public class UpdateUserDto
    {
        [RegularExpression(@"^[a-zA-Z0-9]{18}$", ErrorMessage = "Must contain exactly 18 alphanumeric characters")]

        public string? Curp { get; set; }
        public string? Names { get; set; }
        public string? Lastname { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}