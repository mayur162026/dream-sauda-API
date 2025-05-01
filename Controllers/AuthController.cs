using Microsoft.AspNetCore.Mvc;
using Dreamsauda.Data;
using Dreamsauda.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

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
            try
            {
                // Check if username or password is missing
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new { success = false, message = "Username and password are required." });
                }

                // Fetch user from the database by username
                var loginUser = await _context.LoginUser
                    .FirstOrDefaultAsync(u => u.Username == request.Username);

                // Check if user exists and verify the password
                if (loginUser == null || !BCrypt.Net.BCrypt.Verify(request.Password, loginUser.Password))
                {
                    return Unauthorized(new { success = false, message = "Invalid credentials." });
                }

                // Return success response
                return Ok(new
                {
                    success = true,
                    message = "Login successful",
                    username = loginUser.Username
                });
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Error: {ex.Message}");

                // Return 500 error
                return StatusCode(500, new { success = false, message = "An error occurred while processing your request." });
            }
        }
    }
}
