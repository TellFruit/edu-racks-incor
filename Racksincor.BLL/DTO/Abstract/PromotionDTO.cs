namespace Racksincor.BLL.DTO.Abstract
{
    public abstract class PromotionDTO : BaseDTO
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
    }
}
