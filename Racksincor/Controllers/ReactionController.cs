using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReactionController : ControllerBase
    {
        private readonly IMediateService<ReactionDTO, ReactionQuery> _reactionService;

        public ReactionController(IMediateService<ReactionDTO, ReactionQuery> reactionService)
        {
            _reactionService = reactionService;
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Shopper")]
        public async Task<IActionResult> Create(ReactionDTO reaction)
        {
            try
            {
                var createdReaction = await _reactionService.Create(reaction);

                return Ok(createdReaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var reactions = await _reactionService.ReadWithQuery(default);

                return Ok(reactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var reactionQuery = new ReactionQuery { Id = id };

                var reaction = await _reactionService.ReadWithQuery(reactionQuery);

                if (reaction.Any())
                {
                    return Ok(reaction);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [JwtAuthorize(Roles = "Shopper")]
        public async Task<IActionResult> Update(int id, ReactionDTO reaction)
        {
            try
            {
                reaction.Id = id;
                var updatedReaction = await _reactionService.Update(reaction);
                if (updatedReaction != null)
                {
                    return Ok(updatedReaction);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [JwtAuthorize(Roles = "Shopper")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _reactionService.Delete(new ReactionDTO { Id = id });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
