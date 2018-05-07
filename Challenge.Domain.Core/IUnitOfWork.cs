namespace Challenge.Domain.Core
{
    public interface IUnitOfWork
    {
        void Commit();

        void CommitAndRefresh();

        void Rollback();

        void SetConnectionString(string conectionString);
    }
}
