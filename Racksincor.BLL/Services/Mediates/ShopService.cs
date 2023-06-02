using FluentValidation;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class ShopService : IEntityMediateService<ShopDTO, ShopQuery>
    {
        private readonly IRepository<ShopDTO, ShopQuery> _shopRepository;
        private readonly IValidator<ShopDTO> _shopValidator;

        public ShopService(IRepository<ShopDTO, ShopQuery> shopRepository, IValidator<ShopDTO> shopValidator)
        {
            _shopRepository = shopRepository;
            _shopValidator = shopValidator;
        }

        public async Task<ShopDTO> Create(ShopDTO entry)
        {
            await _shopValidator.ValidateAndThrowAsync(entry);

            return await _shopRepository.Create(entry);
        }

        public async Task<IReadOnlyList<ShopDTO>> ReadWithQuery(ShopQuery? query)
        {
            // Perform any additional business logic or validation here

            return await _shopRepository.ReadWithQuery(query);
        }

        public async Task<ShopDTO> Update(ShopDTO entry)
        {
            await _shopValidator.ValidateAndThrowAsync(entry);

            return await _shopRepository.Update(entry);
        }

        public async Task Delete(ShopDTO entry)
        {
            var shop = await _shopRepository.ReadWithQuery(new ShopQuery { Id = entry.Id });

            await _shopValidator.ValidateAndThrowAsync(shop.First());
            
            await _shopRepository.Delete(new ShopDTO { Id = entry.Id });
        }
    }
}
