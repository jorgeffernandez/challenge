namespace Challenge.InfraestructureAbstract
{
    using System.Data;
   
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
