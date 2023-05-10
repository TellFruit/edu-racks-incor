using Racksincor.DAL.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Models
{
    public class Rack : BaseEntity
    {
        public string Name { get; set; }

        // One-to-One relation: Device and Rack
        public int? DeviceId { get; set; }
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
