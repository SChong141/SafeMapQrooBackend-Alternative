using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROO.Dtos
{
    public class RegisterAdminDto
    {
        [Required]
        public string? Names { get; set; }
        [Required]
        public string? Lastname { get; set; }
        //Talvez se quite 
        //Es nesesario email ?
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
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
                    return Names.Replace(" ", "");
                }
                ;

            }
        }

    }
}