using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IEntityMediateService<ProductDTO, ProductQuery> _productService;

        public ProductController(IEntityMediateService<ProductDTO, ProductQuery> productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Employee")]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            try
            {
                var createdProduct = await _productService.Create(product);

                return Ok(createdProduct);
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
                var products = await _productService.ReadWithQuery(default);

                return Ok(products);
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
                var productQuery = new ProductQuery { Id = id };

                var product = await _productService.ReadWithQuery(productQuery);

                if (product.Any())
                {
                    return Ok(product);
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
        public async Task<IActionResult> Update(int id, ProductDTO product)
        {
            try
            {
                product.Id = id;
                var updatedProduct = await _productService.Update(product);
                if (updatedProduct != null)
                {
                    return Ok(updatedProduct);
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
                await _productService.Delete(new ProductDTO { Id = id });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
