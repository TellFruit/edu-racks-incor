using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    internal class Rack : BaseEntity
    {
        public string Name { get; set; }

        // One-to-One relation: Device and Rack
        public Device Device { get; set; }

        // One-to-Many relation: Rack and Shop
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        // One-to-Many relation: Rack and Product
        public ICollection<Product> Products { get; set; }

        // One-to-Many relation: Rack and Record
        public ICollection<Record> Records { get; set; }
    }
}
