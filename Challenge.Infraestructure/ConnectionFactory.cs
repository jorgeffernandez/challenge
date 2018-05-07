namespace Challenge.Infraestructure
{
    using Challenge.InfraestructureAbstract;
    using Challenge.Shared.Models.AppConfiguration;
    using Microsoft.Extensions.Options;
    using System.Data;
    using System.Data.SqlClient;

    public sealed class ConnectionFactory : IConnectionFactory
    {
        readonly string _sqlConnectionString;
        public ConnectionFactory(IOptions<ConnectionStrings> connectionStrings)
        {
            _sqlConnectionString = connectionStrings.Value.SqlConnectionString;
        }

        public IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(_sqlConnectionString);
            }
        }
    }
}
