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
                Id = appUser.Id,
                UserName = appUser.UserName,
                Names = appUser.Names,
                Lastname = appUser.Lastname,
            };

        }

        public static UserDto ToRetunUserDto(this AppUser appUser)
        {
            return new UserDto
            {
                UserName = appUser.UserName,
                Names = appUser.Names,
                Lastname = appUser.Lastname,
            };


        }
        public static AppUser ToUserFromUpdate(this UpdateUserDto userDto)
        {
            return new AppUser
            {
                Names = userDto.Names,
                Lastname = userDto.Lastname,
                UserName = userDto.UserName,
            };


        }
    }
}