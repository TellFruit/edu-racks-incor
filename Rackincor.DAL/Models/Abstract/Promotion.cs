using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Models.Abstract
{
    public abstract class Promotion : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
