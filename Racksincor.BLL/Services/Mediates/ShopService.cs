using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class ShopService : IMediateService<ShopDTO, ShopQuery>
    {
        private readonly IRepository<ShopDTO, ShopQuery> _shopRepository;

        public ShopService(IRepository<ShopDTO, ShopQuery> shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<ShopDTO> Create(ShopDTO entry)
        {
            // Perform any additional business logic or validation here

            return await _shopRepository.Create(entry);
        }

        public async Task<IReadOnlyList<ShopDTO>> ReadWithQuery(ShopQuery? query)
        {
            // Perform any additional business logic or validation here

            return await _shopRepository.ReadWithQuery(query);
        }

        public async Task<ShopDTO> Update(ShopDTO entry)
        {
            // Perform any additional business logic or validation here

            return await _shopRepository.Update(entry);
        }

        public async Task Delete(ShopDTO entry)
        {
            // Perform any additional business logic or validation here

            await _shopRepository.Delete(new ShopDTO { Id = entry.Id });
        }
    }
}
