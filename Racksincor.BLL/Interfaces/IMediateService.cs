using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.Interfaces
{
    public interface IMediateService<TEntity> where TEntity : BaseDTO
    {
        Task<BaseDTO> Create(BaseDTO entry);
        Task<BaseDTO> Get(int entryId);
        Task<BaseDTO> Update(BaseDTO entry);
        Task Delete(int idd);
    }
}
