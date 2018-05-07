namespace Challenge.Services.Traces
{
    using Challenge.DomainAbstract.Traces;
    using Challenge.ServicesAbstract.Traces;
    using Challenge.Shared.Models.Configuration;

    public class SessionTraceService : ISessionTraceService
    {
        readonly ISessionTraceDomain _sessionTraceDomain;

        public SessionTraceService(ISessionTraceDomain sessionTraceDomain)
        {
            _sessionTraceDomain = sessionTraceDomain;
        }

        public void AddSession(SessionTrace session)
        {
            _sessionTraceDomain.AddSession(session);
        }
    }
}
