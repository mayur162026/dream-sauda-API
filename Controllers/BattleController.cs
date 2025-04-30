using Microsoft.AspNetCore.Mvc;
using Dreamsauda.Data;
using Dreamsauda.Models;
using Microsoft.EntityFrameworkCore;

namespace Dreamsauda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BattleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("join")]
        public async Task<IActionResult> JoinBattle([FromBody] BattleEntry entry)
        {
            _context.BattleEntries.Add(entry);
            await _context.SaveChangesAsync();
            return Ok(entry);
        }

        [HttpGet("match/{matchId}")]
        public async Task<IActionResult> GetBattleEntriesForMatch(int matchId)
        {
            var entries = await _context.BattleEntries
                .Where(be => be.MatchId == matchId)
                .Include(be => be.Team)
                .ToListAsync();

            return Ok(entries);
        }
    }
}
