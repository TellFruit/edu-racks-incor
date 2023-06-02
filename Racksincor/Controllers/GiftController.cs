using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO.Promotion;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly IEntityMediateService<GiftDTO, PromotionQuery> _promotionService;

        public GiftController(IEntityMediateService<GiftDTO, PromotionQuery> promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> Create(GiftDTO gift)
        {
            try
            {
                var createdGift = await _promotionService.Create(gift);

                return Ok(createdGift);
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
                var gifts = await _promotionService.ReadWithQuery(default);

                return Ok(gifts);
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
                var promotionQuery = new PromotionQuery { Id = id };

                var gift = await _promotionService.ReadWithQuery(promotionQuery);

                if (gift.Any())
                {
                    return Ok(gift);
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
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> Update(int id, GiftDTO gift)
        {
            try
            {
                gift.Id = id;
                var updatedGift = await _promotionService.Update(gift);
                if (updatedGift != null)
                {
                    return Ok(updatedGift);
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
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _promotionService.Delete(new GiftDTO { Id = id });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
