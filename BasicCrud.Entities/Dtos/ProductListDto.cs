﻿using BasicCrud.Core.Entities;

namespace BasicCrud.Entities.Dtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}