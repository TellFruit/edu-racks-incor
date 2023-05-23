using Racksincor.BLL.DTO.Abstract;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.DAL.Services.Repositories
{
    public class PromotionRepositor<TEntity, TQuery> : IRepository<TEntity, TQuery>
        where TEntity : PromotionDTO
        where TQuery : PromotionQuery
    {
        public Task<TEntity> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> ReadWithQuery(TQuery? obj)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
