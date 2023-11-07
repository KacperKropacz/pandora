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
    }
}

