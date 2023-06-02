using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.Interfaces
{
    public interface IEntityMediateService<TEntity, TQuery> : IRepository<TEntity, TQuery>
        where TEntity : BaseDTO
        where TQuery : BaseDTO
    {

    }
}
