using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.Queries
{
    public class UserQuery : BaseDTO<int>
    {
        public int ShopId { get; set; }
    }
}
