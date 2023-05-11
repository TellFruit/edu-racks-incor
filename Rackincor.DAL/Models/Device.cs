using Racksincor.DAL.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Models
{
    public class Device : BaseEntity
    {
        // One-to-One relation: Device and Rack
        public int RackId { get; set; }
        public Rack Rack { get; set; }
    }
}
