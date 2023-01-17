using BasicCrud.Core.Entities;
using Dapper.Contrib.Extensions;

namespace BasicCrud.Entities.Concrete
{

    [Dapper.Contrib.Extensions.Table("Products")]
    public class Product : IEntity
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}