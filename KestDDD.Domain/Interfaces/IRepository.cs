using System;
using System.Linq;

namespace KestDDD.Domain.Interfaces
{
    /// <summary>
    /// 定义泛型仓储接口，并继承 IDisposable 显式释放资源
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
