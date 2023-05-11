using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    internal class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        // One-to-Many relation: User and Shop
        public ICollection<User> Users { get; set; }

        // One-to-Many relation: Rack and Shop
        public ICollection<Rack> Racks { get; set; }

        // One-to-Many relation: Product and Shop
        public ICollection<Product> Products { get; set; }

        // One-to-Many relation: Promotion and Shop
        public ICollection<Promotion> Promotions { get; set; }
    }
}
