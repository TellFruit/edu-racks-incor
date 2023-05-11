using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.Interfaces
{
    public interface IRepository<TEntity, TQuery>
        where TEntity : BaseDTO
        where TQuery : BaseDTO
    {
        Task<TEntity> Create(TEntity entity);
        Task<IReadOnlyList<TEntity>> Read();
        Task<IReadOnlyList<TEntity>> ReadWithQuery(TQuery obj);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
