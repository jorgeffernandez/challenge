using Challenge.InfraestructureAbstract;
using Challenge.Shared.Models.Configuration;
using Dapper;
using System;
using System.Collections.Generic;


namespace Challenge.Infraestructure.Repositories
{
    public class SessionTraceRepository : GenericRepository<SessionTrace>, ISessionTraceRepository
    {
        public SessionTraceRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public override void Add(SessionTrace entity)
        {
                var query = "INSERT INTO SessionTrace (SessionId, Action, Segmento,DireccionIp, TipoImplementacion, Entorno, FechaCreacion)" +
                                 "Values (@SessionId, @Action, @Segmento, @DireccionIp, @TipoImplementacion, @Entorno, GETDATE());";

                SqlMapper.Execute(ConnectionFactory.GetConnection, query, entity);
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override SessionTrace Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SessionTrace> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(SessionTrace entity)
        {
            throw new NotImplementedException();
        }
    }

}


