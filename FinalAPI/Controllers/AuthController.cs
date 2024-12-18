﻿
using DAL.Models;
using FinalAPI.DTOs;
using FinalAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class AuthController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<IdentityRole<int>> roleManager,
        JwtService jwtService
        ) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(dto.ToUser(), dto.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }

                //Registration Failed
                return BadRequest(result.Errors);
            }

            //Validation Failed
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(dto.Email);

                //check that email exists
                if (user is null || user.UserName is null)
                {
                    return Unauthorized();
                }

                //verify password
                var result = await signInManager.PasswordSignInAsync(
                    user.UserName, dto.Password, false, false
                );

                if (result.Succeeded)
                {
                    string token = await jwtService.CreateToken(user);

                    return Ok(new {token});
                }
                return Unauthorized();
            }
            return BadRequest(ModelState);
        }
    }
}
