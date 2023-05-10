using Racksincor.DAL.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Models
{
    public class Product
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
