using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO
{
    public class RackDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public int ShopId { get; set; }
    }
}
