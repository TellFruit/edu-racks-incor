using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.Queries
{
    public class RackQuery : BaseDTO<int>
    {
        public int ShopId { get; set; }
    }
}
