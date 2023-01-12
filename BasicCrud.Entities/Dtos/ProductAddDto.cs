using BasicCrud.Core.Entities;

namespace BasicCrud.Entities.Dtos
{
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}