using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO
{
    public class CompanyDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}
