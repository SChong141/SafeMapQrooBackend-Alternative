using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos.Account
{
    public class UpdateUserDto

    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]")]
        public string? Names { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]")]
        public string? Lastname { get; set; }
        public string UserName
        {
            get
            {
                int FirstName = Names.IndexOf(' ');
                if (FirstName != -1)
                {
                    return $"{Names.Substring(0, FirstName)}{Lastname.Replace(" ", "")}";
                }
                else
                {
                    return $"{Names.Replace(" ", "")}{Lastname.Replace(" ", "")}";
                }
                ;

            }
        }
    }
}