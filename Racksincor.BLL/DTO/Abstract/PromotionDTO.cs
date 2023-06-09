namespace Racksincor.BLL.DTO.Abstract
{
    public abstract class PromotionDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ShopId { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
    }
}
