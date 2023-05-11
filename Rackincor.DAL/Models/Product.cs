using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int IsInStock { get; set; }

        // One-to-Many relation: Rack and Product
        public int RackId { get; set; }
        public Rack Rack { get; set; }

        // One-to-Many relation: Promotion and Product
        public ICollection<Promotion> Promotions { get; set; }

        // Many-to-Many relation: User and Product
        public ICollection<Reaction> Reactions { get; set; }
    }
}
