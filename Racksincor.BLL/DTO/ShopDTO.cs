﻿using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO
{
    public class ShopDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CompanyId { get; set; }
    }
}
