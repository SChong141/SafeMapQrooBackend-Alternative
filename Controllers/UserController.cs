using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeMapQROO.Dtos.Account;
using SafeMapQROO.Interface;
using SafeMapQROO.Mappers;

namespace SafeMapQROO.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var UsersModel = await _userRepo.GetAllUsersAsync();
            var UserDto = UsersModel.Select(x => x.ToUserDto()).ToList();
            return Ok(UserDto);
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetById([FromRoute] string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var User = await _userRepo.GetByIdAsync(Id);
            if (User == null) return NotFound();
            return Ok(User.ToRetunUserDto());
        }

        [HttpPut]
        [Route("{Id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateUser([FromRoute] string Id, [FromBody] UpdateUserDto User)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userModel = await _userRepo.UpdateUserAcync(Id, User.ToUserFromUpdate());
            if (userModel == null) return BadRequest("User not found");
            return Ok(userModel.ToRetunUserDto());
        }

        [HttpDelete]
        [Route("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var Exist = await _userRepo.DeleteUserAsync(Id);
            if (Exist == null) return NotFound("User not found");
            return Ok("User Delete");

        }

    }
}