using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.Queries
{
    public class PromotionQuery : BaseDTO<int>
    {
        public int ShopId { get; set; }
        public string Discriminator { get; set; }
    }
}
