namespace Challenge.Infraestructure.Repositories
{
    using Challenge.InfraestructureAbstract;
    using System.Collections.Generic;
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal IConnectionFactory ConnectionFactory;

        protected GenericRepository(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public abstract void Add(TEntity entity);

        public abstract void Delete(int id);

        public abstract void Update(TEntity entity);

        public abstract TEntity Get(int id);

        public abstract IEnumerable<TEntity> GetAll();
    }
}
