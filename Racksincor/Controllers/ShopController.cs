using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [JwtAuthorize(Roles = "Admin")]
    public class ShopController : ControllerBase
    {
        private readonly IEntityMediateService<ShopDTO, ShopQuery> _shopService;

        public ShopController(IEntityMediateService<ShopDTO, ShopQuery> shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopDTO shop)
        {
            try
            {
                var createdShop = await _shopService.Create(shop);
                return Ok(createdShop);
            }
            catch (ValidationException ex)
            {
                ex.AddToModelState(ModelState);

                return BadRequest(ModelState);
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
                var shops = await _shopService.ReadWithQuery(default);
                return Ok(shops);
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
                var shopQuery = new ShopQuery { Id = id };
                var shop = await _shopService.ReadWithQuery(shopQuery);

                if (shop.Any())
                {
                    return Ok(shop);
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

        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetByCompanyId(int id)
        {
            try
            {
                var shopQuery = new ShopQuery { CompanyId = id };
                var shop = await _shopService.ReadWithQuery(shopQuery);

                if (shop.Any())
                {
                    return Ok(shop);
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
        public async Task<IActionResult> Update(int id, ShopDTO shop)
        {
            try
            {
                shop.Id = id;
                var updatedShop = await _shopService.Update(shop);

                if (updatedShop != null)
                {
                    return Ok(updatedShop);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ValidationException ex)
            {
                ex.AddToModelState(ModelState);

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopService.Delete(new ShopDTO { Id = id });

                return NoContent();
            }
            // TODO: lacks validation exception handler
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
