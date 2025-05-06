using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Config;
using ApiRest.Data;
using ApiRest.DTOs;
using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Utilities _utilities;

        public AuthController(AppDbContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        [HttpPost("/api/register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(dto.Username) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Password))
            {
                return BadRequest(new { message = "Username, Email and Password are required" });
            }

            var emailExists = _context.Users.Any(u => u.Email == dto.Email);
            if (emailExists)
            {
                return Conflict(new { message = "Email already exists" });
            }

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = _utilities.EncryptSHA256(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully", userId = user.Id });
        }


        //Login endpoint
        [HttpPost("/api/login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var User = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (User == null)
            {
                return Unauthorized("Invalid email");
            }

            var passwordIsValid = User.Password == _utilities.EncryptSHA256(userDto.Password);

            if (!passwordIsValid)
            {
                return Unauthorized("Invalid password");
            }

            var token = _utilities.GenerateJwtToken(User);
            return Ok(new
            {
                message = "Please store this token:",
                jwt = token
            });
        }
    }
}