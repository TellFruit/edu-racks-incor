using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.Queries
{
    public class ProductQuery : BaseDTO<int>
    {
        public int ShopId { get; set; }
        public int RackId { get; set; }
    }
}
