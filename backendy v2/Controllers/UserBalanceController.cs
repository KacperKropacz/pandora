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
                .Where(ms => ms.Id == userId)
                .Select(ms => ms.MoneyBalance)
                .FirstOrDefaultAsync();

            if (userBalance == 0)
                return NotFound("User not found or balance is not thwew");

            return userBalance;
        }

    }
}