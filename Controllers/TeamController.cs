using Microsoft.AspNetCore.Mvc;
using Dreamsauda.Data;
using Dreamsauda.Models;
using Microsoft.EntityFrameworkCore;

namespace Dreamsauda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _context.Teams
                .Include(t => t.TeamStocks!)
                .ThenInclude(ts => ts.Stock)
                .FirstOrDefaultAsync(t => t.Id == id);

            return team == null ? NotFound() : Ok(team);
        }
    }
}
