using System.Linq;

namespace Challenge.Domain.Core
{
    public interface IReportsRepository<T> where T : class
    {
        IQueryable<T> GetAll();
    }
}
