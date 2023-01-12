using BasicCrud.Core.DataAccess.EntityFramework;
using BasicCrud.DataAccess.Abstract;
using BasicCrud.DataAccess.Concrete.EntityFramework.Contexts;
using BasicCrud.Entities.Concrete;

namespace BasicCrud.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfProductDal : EfEntityRepositoryBase<Product, BasicCrudContext>, IProductDal
    {
    }
}