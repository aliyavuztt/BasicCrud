using BasicCrud.Business.Abstract;
using BasicCrud.Business.Concrete;
using BasicCrud.DataAccess.Abstract;
using BasicCrud.DataAccess.Concrete.EntityFramework.Contexts;
using BasicCrud.DataAccess.Concrete.EntityFramework.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BasicCrud.Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BasicCrudContext>();

            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<IProductDal, EfProductDal>();

            return serviceCollection;
        }
    }
}
