using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Models
{
    public class Reaction
    {
        public bool IsPositive { get; set; }

        // Many-to-Many relation: User-Product
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
