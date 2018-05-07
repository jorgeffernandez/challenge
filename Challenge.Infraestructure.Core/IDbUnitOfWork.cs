using Challenge.Domain.Core;
using System.Data.Entity;

namespace Challenge.Infraestructure.Core
{
    public interface IDbUnitOfWork : IUnitOfWork
    {
        void RegisterChanges<TEntity>(TEntity item) where TEntity : class;

        void Unregister<TEntity>(TEntity item) where TEntity : class;

        DbSet<TEntity> CreateDbSet<TEntity>() where TEntity : class;
    }
}
