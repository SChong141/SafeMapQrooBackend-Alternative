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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
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
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user)
                }
            );
        }

        [HttpPost("registerAdmin")]
        // [Authorize(Roles = "Admin,Organizer")]
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
                    UserName = registerAdminDTO.Username,
                    Email = registerAdminDTO.Email
                };

                var updateUser = await _userManager.CreateAsync(appUser, registerAdminDTO.Password);

                if (updateUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Admin");

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewLoginDTO
                            {
                                Id = appUser.Id,
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = await _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, updateUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("registerOrganizer")]
        public async Task<IActionResult> RegisterOrganizer([FromBody] RegisterOrganizerDTO registerOrganizerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerOrganizerDTO.Username,
                    Email = registerOrganizerDTO.Email,
                    PhoneNumber = registerOrganizerDTO.PhoneNumber,
                    AssignedShelter = registerOrganizerDTO.AssignedShelter
                };

                var updateUser = await _userManager.CreateAsync(appUser, registerOrganizerDTO.Password);

                if (updateUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Organizer");

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewLoginDTO
                            {
                                Id = appUser.Id,
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = await _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, updateUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateDTO updateDTO)
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
                        new UpdateDTO
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
    }
}