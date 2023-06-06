using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RackController : ControllerBase
    {
        private readonly IEntityMediateService<RackDTO, RackQuery> _rackService;

        public RackController(IEntityMediateService<RackDTO, RackQuery> rackService)
        {
            _rackService = rackService;
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> Create(RackDTO rack)
        {
            try
            {
                var createdRack = await _rackService.Create(rack);

                return Ok(createdRack);
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
                var racks = await _rackService.ReadWithQuery(default);

                return Ok(racks);
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
                var rackQuery = new RackQuery { Id = id };

                var rack = await _rackService.ReadWithQuery(rackQuery);

                if (rack.Any())
                {
                    return Ok(rack);
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

                var rackQuery = new RackQuery { ShopId = id };

                var racks = await _rackService.ReadWithQuery(rackQuery);

                if (racks.Any())
                {
                    return Ok(racks);
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
        public async Task<IActionResult> Update(int id, RackDTO rack)
        {
            try
            {
                rack.Id = id;
                var updatedRack = await _rackService.Update(rack);
                if (updatedRack != null)
                {
                    return Ok(updatedRack);
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
                await _rackService.Delete(new RackDTO { Id = id });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
