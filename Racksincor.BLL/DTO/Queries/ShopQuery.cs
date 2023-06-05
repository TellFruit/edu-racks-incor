using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.Queries
{
    public class ShopQuery : BaseDTO<int>
    {
        public int CompanyId { get; set; }
    }
}
