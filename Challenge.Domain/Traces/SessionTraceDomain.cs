namespace Challenge.Domain.Traces
{
    using Challenge.DomainAbstract.Traces;
    using Challenge.InfraestructureAbstract;
    using Challenge.Shared.Models.Configuration;

    public class SessionTraceDomain : ISessionTraceDomain
    {
        readonly ISessionTraceRepository _sessionTraceRepository;
        public SessionTraceDomain(ISessionTraceRepository sessionTraceRepository)
        {
            _sessionTraceRepository = sessionTraceRepository;
        }

        public void AddSession(SessionTrace session)
        {
            _sessionTraceRepository.Add(session);
        }
        
    }
}
