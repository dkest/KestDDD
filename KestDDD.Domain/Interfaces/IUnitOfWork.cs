using System;

namespace KestDDD.Domain.Interfaces
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
