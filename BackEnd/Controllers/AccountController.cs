using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Services;
using Proiect_O_A.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        public AccountController(UserManager<User> userManager,IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }
        [HttpPost]
        [Route("register/admin")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserAdminAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost]
        [Route("register/user")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserUserAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost]
        [Route("register/bucatar")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterBucatar([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserBucatarAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost]
        [Route("register/responsabilmag")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterResponsabilMag([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserResponsabilMagAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);


            if (token == "")
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
