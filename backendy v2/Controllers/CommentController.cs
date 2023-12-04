using Backendy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentTable>>> GetAllComments()
        {
            return await _dbContext.comment_table.ToListAsync();
        }

        [HttpGet("{commentId}")]
        public async Task<ActionResult<CommentTable>> GetCommentById(int commentId)
        {
            var comment = await _dbContext.comment_table.FindAsync(commentId);

            if (comment == null)
                return NotFound("Comment not found.");

            return comment;
        }

    }
}
