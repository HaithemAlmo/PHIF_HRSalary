using System;
using System.Linq.Expressions;

namespace Almotkaml.Repository
{
    public interface IDefaultUnitOfWork : IDisposable
    {
        string Message { get; }

        [Obsolete("Use the notify method of Complete")]
        void Complete();

        [Obsolete("Use the notify method of TryComplete")]
        bool TryComplete();
        bool BackUp(string path);
        bool Restore(string path);
    }
    public interface IDefaultUnitOfWork<TNotify> : IDefaultUnitOfWork
    {
        void Complete(Expression<Func<TNotify, bool>> expression);
        bool TryComplete(Expression<Func<TNotify, bool>> expression);
    }
}
