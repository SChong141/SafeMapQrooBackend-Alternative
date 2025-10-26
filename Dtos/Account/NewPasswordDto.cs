using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos.Account
{
    public class NewPasswordDto
    {
        [Required]
        public string Password { get; set; }
    }
}