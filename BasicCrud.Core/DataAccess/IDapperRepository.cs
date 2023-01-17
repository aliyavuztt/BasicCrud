using BasicCrud.Core.Entities;

namespace BasicCrud.Core.DataAccess
{
    public interface IDapperRepository<T> where T : class, IEntity, new()
    {
        T GetById(int id);
        IList<T> GetList();
        IList<T> GetList(string name);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}