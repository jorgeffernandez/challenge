using Challenge.Domain.Core;
using Challenge.Domain.Entities;
using System.Collections.Generic;

namespace Challenge.Domain
{
    public interface IPhonesRepository : IRepository<Phones>
    {
        IEnumerable<Phones> GetPhones(int take, int skip, out int total);
    }
}
