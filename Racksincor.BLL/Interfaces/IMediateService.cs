using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.Interfaces
{
    public interface IMediateService<TEntity, TQuery> : IRepository<TEntity, TQuery>
        where TEntity : BaseDTO
        where TQuery : BaseDTO
    {

    }
}
