﻿using Racksincor.DAL.Models.Abstract;

namespace Racksincor.DAL.Models
{
    internal class Device : BaseEntity
    {
        // One-to-One relation: Device and Rack
        public int RackId { get; set; }
        public Rack Rack { get; set; }
    }
}
