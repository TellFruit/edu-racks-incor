using Microsoft.AspNetCore.Identity;

namespace Racksincor.DAL.Models
{
    public class User : IdentityUser
    {
        // One-to-Many relation: User and Shop
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        // Many-to-Many relation: User-Product (Reaction)
        public ICollection<Reaction> Reactions { get; set; }

        // Many-to-Many relation: User-Rack
        public ICollection<Rack> Racks { get; set; }
    }
}
