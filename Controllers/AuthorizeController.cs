using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeMapQROOBackend.Dtos.Account;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Controllers
{
    [Route("api/authorize")]
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
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email.ToLower());

            if (user == null)
            {
                return Unauthorized("Invalid user.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Username not found and/or password incorrect.");
            }

            return Ok(
                new NewLoginDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user)
                }
            );
        }

        [HttpPost("registerAdmin")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDTO registerAdminDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerAdminDTO.UserName,
                    Email = registerAdminDTO.Email
                };

                var ExistUser = await _userManager.FindByEmailAsync(registerAdminDTO.Email);

                if (ExistUser != null)
                {
                    return BadRequest("Email Exist");
                }

                var registerUser = await _register.RegisterNewUserAsyn(appUser, "Admin", registerAdminDTO.Password);

                if (registerUser == null)
                {
                    return BadRequest(registerUser);
                }

                return Ok(registerUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        
        [HttpPost("registerOrganizer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterOrganizer([FromBody] RegisterOrganizerDTO registerOrganizerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ExistUser = await _userManager.FindByEmailAsync(registerOrganizerDTO.Email);

                if (ExistUser != null)
                {
                    return BadRequest("Email Exist");
                }

                var appUser = new AppUser
                {
                    UserName = registerOrganizerDTO.UserName,
                    Email = registerOrganizerDTO.Email,
                    PhoneNumber = registerOrganizerDTO.PhoneNumber,
                    AssignedShelter = registerOrganizerDTO.AssignedShelter
                };

                var registerUser = await _register.RegisterNewUserAsyn(appUser, "Organizer", registerOrganizerDTO.Password);

                if (registerUser == null)
                {
                    return BadRequest(registerUser);
                }
                
                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO updateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.FindByIdAsync(updateDTO.Id);

                if (user == null)
                {
                    return Unauthorized("Invalid user.");
                }

                user.UserName = updateDTO.UserName;
                user.Email = updateDTO.Email;

                var updatedUser = await _userManager.UpdateAsync(user);

                if (updatedUser.Succeeded)
                {
                    return Ok(
                        new UpdateUserDTO
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email
                        }
                    );
                }
                else
                {
                    return StatusCode(500, updatedUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /*[HttpGet("{Token}")]
        public async Task<IActionResult> GetRol([FromRoute] string Token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rol = _register.GetRolAsync(Token);
            
            if (rol == null)
            {
                return BadRequest("No exist rol");
            }

            return Ok(rol);
        }*/
    }
}