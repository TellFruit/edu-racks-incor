using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    // TODO: add many-to-one relationship with shop
    internal class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }

        // Many-to-Many relation: Promotion and Product
        public ICollection<Promotion> Promotions { get; set; }

        // Many-to-Many relation: User and Product
        public ICollection<Reaction> Reactions { get; set; }

        // Many-to-Many relation: Product and Rack
        public ICollection<Rack> Racks { get; set; }
    }
}
