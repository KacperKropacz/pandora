using Backendy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backendy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserBalanceController : ControllerBase
    {
        private readonly backendDBContext _dbContext;
        public UserBalanceController(backendDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<moneySystem>>> GetEverything()
        {
            return await _dbContext.money_system.ToListAsync();
        }
        
        [HttpGet("{userId}")]
        public async Task<ActionResult<decimal>> GetBalance(int userId)
        {
            var userBalance = await _dbContext.money_system
                .Where(ms => ms.id == userId)
                .Select(ms => ms.MoneyBalance)
                .FirstOrDefaultAsync();

            if (userBalance == 0)
                return NotFound("User not found or balance is not thwew");

            return userBalance;
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> SetBalance(int userId, [FromBody] decimal newBalance)
        {
            var userBalance = await _dbContext.money_system.FirstOrDefaultAsync(ms => ms.id == userId);

            if (userBalance == null)
                return NotFound("User not found.");

            userBalance.MoneyBalance = newBalance;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}