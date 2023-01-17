using BasicCrud.Business.Abstract;
using BasicCrud.Business.Concrete;
using BasicCrud.Core.Utilities.Security.Jwt;
using BasicCrud.DataAccess.Abstract;
using BasicCrud.DataAccess.Concrete.Dapper.Repository;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace BasicCrud.Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddDbContext<BasicCrudContext>();

            serviceCollection.AddTransient<IDbConnection>(connection => new NpgsqlConnection("Server=localhost;Port=5432;Database=BasicCrud;User Id=postgres;Password=12345;"));

            serviceCollection.AddScoped<IProductService, ProductManager1>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            serviceCollection.AddScoped<IAuthService, AuthManager>();
            serviceCollection.AddScoped<ITokenHelper, JwtHelper>();

            return serviceCollection;
        }
    }
}
