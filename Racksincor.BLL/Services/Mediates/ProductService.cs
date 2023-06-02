using FluentValidation;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class ProductService : IEntityMediateService<ProductDTO, ProductQuery>
    {
        private readonly IRepository<ProductDTO, ProductQuery> _productRepository;

        public ProductService(IRepository<ProductDTO, ProductQuery> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Create(ProductDTO entry)
        {
            return await _productRepository.Create(entry);
        }

        public async Task<IReadOnlyList<ProductDTO>> ReadWithQuery(ProductQuery? query)
        {
            return await _productRepository.ReadWithQuery(query);
        }

        public async Task<ProductDTO> Update(ProductDTO entry)
        {

            return await _productRepository.Update(entry);
        }

        public async Task Delete(ProductDTO entry)
        {
            var product = await _productRepository.ReadWithQuery(new ProductQuery { Id = entry.Id });

            await _productRepository.Delete(new ProductDTO { Id = entry.Id });
        }
    }
}
