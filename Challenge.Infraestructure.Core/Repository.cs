using Challenge.Domain.Core;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Challenge.Infraestructure.Core
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
       where TEntity : class
    {
        #region Propiedades privadas
        private IDbUnitOfWork _currentUoW;
        #endregion

        public Repository(IDbUnitOfWork uoW)
        {
            this._currentUoW = uoW;
        }

        /// <summary>
        /// 
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _currentUoW as IUnitOfWork;
            }
        }

        public void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException();
            DbSet<TEntity> mngEntity = _currentUoW.CreateDbSet<TEntity>();

            mngEntity.Add(item);
        }

        public void Update(TEntity item)
        {
            if (item == null)
                throw new ArgumentException();
            _currentUoW.RegisterChanges<TEntity>(item);
        }

        public void Delete(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException();
            DbSet<TEntity> mngEntity = _currentUoW.CreateDbSet<TEntity>();
            mngEntity.Remove(item);
        }

        public void Register(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException();
            DbSet<TEntity> mngEntity = _currentUoW.CreateDbSet<TEntity>();
            mngEntity.Attach(item);
        }

        public void UnRegister(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException();
            _currentUoW.Unregister<TEntity>(item);
        }

        public IQueryable<TEntity> GetAll(Func<TEntity, bool> filter = null)
        {
            DbSet<TEntity> mngEntity = _currentUoW.CreateDbSet<TEntity>();

            if (filter == null)
                return mngEntity;
            else
                return mngEntity.Where(filter).AsQueryable();
        }

        public IQueryable<TEntity> GetAllDistinct(Expression<Func<TEntity, bool>> filter = null)
        {
            DbSet<TEntity> mngEntity = _currentUoW.CreateDbSet<TEntity>();

            if (filter == null)
                return mngEntity.Distinct();
            else
                return mngEntity.Where(filter).Distinct();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException();
            DbSet<TEntity> filterEntities = _currentUoW.CreateDbSet<TEntity>();
            return filterEntities.Where(filter);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            DbSet<TEntity> objectSet = _currentUoW.CreateDbSet<TEntity>();

            if (where != null)
                return objectSet.Single(where);
            else
                return objectSet.Single();
        }

        public IQueryable<TEntity> GetPagedElements<S>(int pageIndex, int pageCount, Expression<Func<TEntity, S>> orderExpression, bool ascending)
        {
            DbSet<TEntity> objectSet = _currentUoW.CreateDbSet<TEntity>();
            return objectSet.Paginate<TEntity, S>(orderExpression, pageIndex, pageCount, ascending);
        }

        public IQueryable<TEntity> GetPagedWithFilter<S>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageCount,
            Expression<Func<TEntity, S>> orderExpression, bool ascending)
        {
            DbSet<TEntity> objectSet = _currentUoW.CreateDbSet<TEntity>();
            return objectSet.Paginate<TEntity, S>(orderExpression, pageIndex, pageCount, ascending, filter);
        }


        DbSet<TEntity> CreateSet()
        {
            DbSet<TEntity> objectSet = _currentUoW.CreateDbSet<TEntity>();
            return objectSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string GetLanguage()
        {
            //TODO: atención cambiar. Código harcodeado, Código por agente.
            return "es-ES";
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
