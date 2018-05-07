namespace Challenge.ServicesAbstract.Traces
{
    using Challenge.Shared.Models.Configuration;
    public interface ISessionTraceService
    {
        void AddSession(SessionTrace session);
    }
}
