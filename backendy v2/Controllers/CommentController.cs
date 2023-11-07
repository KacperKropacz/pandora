using Backendy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backendy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly backendDBContext _dbContext;
        public CommentController(backendDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO
    }
}
