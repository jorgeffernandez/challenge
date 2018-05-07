namespace Challenge.DomainAbstract.Traces
{
    using Challenge.Shared.Models.Configuration;

    public interface ISessionTraceDomain
    {
        void AddSession(SessionTrace session);
    }
}