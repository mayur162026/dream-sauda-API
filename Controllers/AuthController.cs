using Microsoft.AspNetCore.Mvc;
using Dreamsauda.Data;
using Dreamsauda.Models;
using Microsoft.EntityFrameworkCore;

namespace Dreamsauda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var LoginUser = await _context.LoginUser
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password);

            if (LoginUser == null)
            {
                 
                return Unauthorized("Invalid credentials.");
            }

            // Optionally: return token or user data
            return Ok(new
            {
                 
                success = true,
                message = "Login successful",
                LoginUser.Username,
                LoginUser.Password
            });
        }
    }
}
