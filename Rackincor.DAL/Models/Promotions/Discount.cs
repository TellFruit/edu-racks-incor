using Racksincor.DAL.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Models.Promotions
{
    public class Discount : Promotion
    {
        public int Percenatage { get; set; }
    }
}
