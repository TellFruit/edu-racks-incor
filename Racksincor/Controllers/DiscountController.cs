using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO.Promotion;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IEntityMediateService<DiscountDTO, PromotionQuery> _promotionService;

        public DiscountController(IEntityMediateService<DiscountDTO, PromotionQuery> promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> Create(DiscountDTO discount)
        {
            try
            {
                var createdDiscount = await _promotionService.Create(discount);

                return Ok(createdDiscount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var discounts = await _promotionService.ReadWithQuery(default);

                return Ok(discounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var promotionQuery = new PromotionQuery { Id = id };

                var discount = await _promotionService.ReadWithQuery(promotionQuery);

                if (discount.Any())
                {
                    return Ok(discount);
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

        [HttpGet("shop")]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> GetByShop()
        {
            try
            {
                var id = int.Parse(HttpContext.GetTokenClaim("shopId"));

                var promotionQuery = new PromotionQuery { ShopId = id };

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
        public async Task<IActionResult> Update(int id, DiscountDTO discount)
        {
            try
            {
                discount.Id = id;
                var updatedDiscount = await _promotionService.Update(discount);
                if (updatedDiscount != null)
                {
                    return Ok(updatedDiscount);
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
                await _promotionService.Delete(new DiscountDTO { Id = id });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
