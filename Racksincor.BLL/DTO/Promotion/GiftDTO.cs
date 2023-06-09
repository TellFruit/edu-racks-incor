using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.Promotion
{
    public class GiftDTO : PromotionDTO
    {
        public int GiftProductId { get; set; }
        public ProductDTO? Product { get; set; }
    }
}
