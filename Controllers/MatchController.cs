using Microsoft.AspNetCore.Mvc;
using Dreamsauda.Data;
using Dreamsauda.Models;
using Microsoft.EntityFrameworkCore;

namespace Dreamsauda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MatchController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return Ok(match);
        }

        [HttpGet]
        public async Task<IActionResult> GetMatches()
        {
            var matches = await _context.Matches.ToListAsync();
            return Ok(matches);
        }
    }
}
