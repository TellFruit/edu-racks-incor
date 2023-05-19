using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int IsInStock { get; set; }
        public int RackId { get; set; }
    }
}
