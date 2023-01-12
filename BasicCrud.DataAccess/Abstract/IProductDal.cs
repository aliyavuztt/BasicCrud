﻿using BasicCrud.Core.DataAccess;
using BasicCrud.Entities.Concrete;

namespace BasicCrud.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}