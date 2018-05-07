namespace Challenge.InfraestructureAbstract
{
    using System.Collections.Generic;
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}