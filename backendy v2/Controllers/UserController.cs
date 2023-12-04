using Backendy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backendy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly backendDBContext _dbContext;
        public UserController(backendDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetEverything()
        {
            return await _dbContext.user_table.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserTable>> GetUserById(int userId)
        {
            var user = await _dbContext.user_table.FindAsync(userId);

            if (user == null)
                return NotFound("User not found.");

            return user;
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _dbContext.user_table.FindAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            _dbContext.user_table.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}

