using Microsoft.AspNetCore.Mvc;
using Dreamsauda.Data;
using Dreamsauda.Models;
using Microsoft.EntityFrameworkCore;

namespace Dreamsauda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return Ok(stock);
        }
    }
}
