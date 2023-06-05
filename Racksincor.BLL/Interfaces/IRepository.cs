using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.Interfaces
{
    public interface IRepository<TEntity, TQuery>
        where TEntity : class
        where TQuery : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<IReadOnlyList<TEntity>> ReadWithQuery(TQuery? obj);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
