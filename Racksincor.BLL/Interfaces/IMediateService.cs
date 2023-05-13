using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.Interfaces
{
    public interface IMediateService<TEntity, TQuery>
        where TEntity : BaseDTO
        where TQuery : BaseDTO
    {
        Task<TEntity> Create(TEntity entry);
        Task<IReadOnlyList<TEntity>> Get (TQuery query);
        Task<TEntity> Update(TEntity entry);
        Task Delete(int id);
    }
}
