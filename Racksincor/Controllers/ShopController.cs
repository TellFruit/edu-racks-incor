using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IRepository<ShopDTO, ShopQuery> _shopRepository;

        public ShopController(IRepository<ShopDTO, ShopQuery> shopRepository)
        {
            _shopRepository = shopRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopDTO shopDTO)
        {
            var createdShop = await _shopRepository.Create(shopDTO);
            return Ok(createdShop);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var shops = await _shopRepository.ReadWithQuery(default);

            return Ok(shops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var shopQuery = new ShopQuery { Id = id };
            var shops = await _shopRepository.ReadWithQuery(shopQuery);
            return Ok(shops);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ShopDTO shopDTO)
        {
            var updatedShop = await _shopRepository.Update(shopDTO);
            return Ok(updatedShop);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shopDTO = new ShopDTO { Id = id };
            await _shopRepository.Delete(shopDTO);
            return NoContent();
        }
    }
}
