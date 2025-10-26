using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeMapQROO.Dtos;
using SafeMapQROO.Dtos.Account;
using SafeMapQROO.Interface;
using SafeMapQROO.Models;

namespace SafeMapQROO.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRegisterRepository _register;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IRegisterRepository register)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _register = register;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var User = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (User == null)
                return Unauthorized("Invalid Username");
            var result = await _signInManager.CheckPasswordSignInAsync(User, loginDto.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Username not found and/or password incorrect");


            return Ok(new NewUserDto
            {
                UserName = User.UserName,
                Email = User.Email,
                Token = _tokenService.CreateToken(User)

            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto regiUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var ExistUser = await _userManager.FindByEmailAsync(regiUserDto.Email);
                if (ExistUser != null) return BadRequest("Email Exist");


                var appUser = new AppUser
                {
                    UserName = regiUserDto.UserName,
                    Names = regiUserDto.Names,
                    Lastname = regiUserDto.Lastname,
                    Email = regiUserDto.Email,
                    Curp = regiUserDto.Curp.ToUpper(),
                };

                var registerUser = await _register.RegisterNewUserAsyn(appUser, "User", regiUserDto.Password);

                if (registerUser == null) return BadRequest(registerUser);

                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpPost("registerAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDto regiAdminDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var ExistUser = await _userManager.FindByEmailAsync(regiAdminDto.Email);
                if (ExistUser != null) return BadRequest("Email Exist");


                var appUser = new AppUser
                {
                    UserName = regiAdminDto.UserName,
                    Names = regiAdminDto.Names,
                    Lastname = regiAdminDto.Lastname,
                    Email = regiAdminDto.Email,
                };

                var registerUser = await _register.RegisterNewUserAsyn(appUser, "Admin", regiAdminDto.Password);

                if (registerUser == null) return BadRequest(registerUser);

                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("NewPassword{Email}")]
        public async Task<IActionResult> UpdatePassword([FromRoute] string Email, [FromBody] NewPasswordDto newPassword)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var Resultpass = await _register.NewPasswordAsync(Email, newPassword.Password);
            if (Resultpass == null) return BadRequest("Error");
            return NoContent();
        }
    }
}