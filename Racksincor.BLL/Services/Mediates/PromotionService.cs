using Racksincor.BLL.DTO.Abstract;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class PromotionService<TEntity, TQuery> : IEntityMediateService<TEntity, TQuery>
        where TEntity : PromotionDTO, new()
        where TQuery : PromotionQuery
    {
        private IRepository<TEntity, TQuery> _promotionRepository;

        public PromotionService(IRepository<TEntity, TQuery> promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            return await _promotionRepository.Create(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await (_promotionRepository.Delete(entity));
        }

        public async Task<IReadOnlyList<TEntity>> ReadWithQuery(TQuery? obj)
        {
            if (obj != null)
            {
                obj.Discriminator = typeof(TEntity).Name;
            }

            return await _promotionRepository.ReadWithQuery(obj);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _promotionRepository.Update(entity);
        }
    }
}
