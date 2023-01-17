using BasicCrud.DataAccess.Abstract;
using BasicCrud.Entities.Concrete;
using Dapper;
using System.Data;

namespace BasicCrud.DataAccess.Concrete.Dapper.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Product entity)
        {
            var sql = "Insert into Products (Name,Stock,Price,CreatedDate,ModifiedDate) VALUES (@Name,@Stock,@Price,@CreatedDate,@ModifiedDate)";
            _dbConnection.Execute(sql, entity);
        }

        public void Update(Product entity)
        {
            var sql = "Update Products SET Name = @Name, Stock = @Stock, Price = @Price, ModifiedDate = @ModifiedDate Where Id = @Id";
            _dbConnection.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "Delete From Products WHERE Id = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }

        public Product GetById(int id)
        {
            var sql = "Select * From Products Where Id = @Id";
            return _dbConnection.QuerySingleOrDefault<Product>(sql, new { Id = id });
        }

        public IList<Product> GetList()
        {
            var sql = "Select * From Products";
            return _dbConnection.Query<Product>(sql).ToList();
        }

        public IList<Product> GetList(string name)
        {
            var sql = "Select * From Products Where Name='" + name + "'";
            return _dbConnection.Query<Product>(sql).ToList();
        }
    }
}
