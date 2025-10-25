using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROO.Dtos.Account;
using SafeMapQROO.Models;

namespace SafeMapQROO.Mappers
{
    public static class AccountMappers
    {
        public static UserDto ToUserDto(this AppUser appUser)
        {
            return new UserDto
            {
                Names = appUser.Names,
                Lastname = appUser.Lastname,
                Curp = appUser.Curp,
                Email = appUser.Email,
            };


        }
        public static AppUser ToUserFromUpdate(this UpdateUserDto userDto)
        {
            return new AppUser
            {
                Names = userDto.Names,
                Lastname = userDto.Lastname,
                Curp = userDto.Curp,
            };


        }
    }
}