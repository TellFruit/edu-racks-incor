using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        // One-to-Many relation: Company and Shop
        public ICollection<Shop> Shops { get; set; }
    }
}
