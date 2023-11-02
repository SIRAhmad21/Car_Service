using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        public IBaseRepository<Comment> baseRepository;
        public CommentController(IBaseRepository<Comment> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var comments = baseRepository.GetAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comment = baseRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {
            baseRepository.Add(comment);

            return CreatedAtAction(nameof(Get), new { id = comment.Commentid }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment updatedComment)
        {
            var existingComment = baseRepository.GetById(id);

            if (existingComment == null)
            {
                return NotFound();
            }

            baseRepository.UPdate(id, updatedComment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = baseRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            baseRepository.Delete(id);

            return NoContent();
        }

    }
}
