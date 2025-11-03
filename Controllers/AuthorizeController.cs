using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SafeMapQROO.Dtos;
using SafeMapQROO.Dtos.Account;
using SafeMapQROO.Interface;
using SafeMapQROO.Models;


namespace SafeMapQROO.Controllers
{
    [Route("api/Authorize")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IAuthorizeRepository _register;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthorizeController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IAuthorizeRepository register)
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


            return Ok(new InfoUserDto
            {
                UserName = User.UserName,
                Email = User.Email,
                Token = await _tokenService.CreateToken(User)

            });

        }


        [HttpGet("{Token}")]
        public async Task<IActionResult> GetRol([FromRoute] string Token)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var rol = _register.GetRolAsync(Token);
            if (rol == null) return BadRequest("No exist rol");
            return Ok(rol);
        }



        [HttpPost("registerCitizen")]
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
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var ExistUser = await _userManager.FindByEmailAsync(userDto.Email);
                if (ExistUser != null) return BadRequest("Email Exist");


                var appUser = new AppUser
                {
                    UserName = userDto.UserName,
                    Names = userDto.Names,
                    Lastname = userDto.Lastname,
                    Email = userDto.Email,
                };

                var registerUser = await _register.RegisterNewUserAsyn(appUser, "Admin", userDto.Password);

                if (registerUser == null) return BadRequest(registerUser);

                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("registerEmployee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var ExistUser = await _userManager.FindByEmailAsync(userDto.Email);
                if (ExistUser != null) return BadRequest("Email Exist");


                var appUser = new AppUser
                {
                    UserName = userDto.UserName,
                    Names = userDto.Names,
                    Lastname = userDto.Lastname,
                };

                var registerUser = await _register.RegisterNewUserAsyn(appUser, "Employee", userDto.Password);

                if (registerUser == null) return BadRequest(registerUser);

                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("NewPassword{Email}")]
        [Authorize(Roles = "Admin,Employee,User")]
        public async Task<IActionResult> UpdatePassword([FromRoute] string Email, [FromBody] NewPasswordDto newPassword)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var Resultpass = await _register.NewPasswordAsync(Email, newPassword.Password);
            if (Resultpass == null) return BadRequest("Error");
            return NoContent();
        }


    }
}