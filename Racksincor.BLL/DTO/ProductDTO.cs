﻿using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO
{
    public class ProductDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
        public int ShopId { get; set; }
    }
}
