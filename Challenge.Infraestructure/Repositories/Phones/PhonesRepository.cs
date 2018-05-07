using Challenge.Domain;
using Challenge.Domain.Entities;
using Challenge.Infraestructure.Core;
using Challenge.Infraestructure.DataContext;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Challenge.Infraestructure.Repositories
{
    public class PhonesRepository : Repository<Phones>, IPhonesRepository
    {
        public PhonesRepository([Dependency("Phones")] IDbUnitOfWork uoW) : base(uoW) { }

        #region Private Methods

        private ChallengeEntities _context = new ChallengeEntities();

        private ChallengeEntities context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ChallengeEntities();
                }

                return _context;
            }
        }

        #endregion

        #region Public Methods

        public IEnumerable<Phones> GetPhones(int take, int skip, out int total)
        {
            IEnumerable<Phones> result = null;
            result = ((IDbUnitOfWork)UnitOfWork).CreateDbSet<Phones>()
                                                .OrderBy(c => c.id_i);
            if (result != null && result.Any())
                total = result.Count();
            else
                total = 0;

            if (take == -1)
                return result;
            else
                return result.Skip(skip * take).Take(take);
        }

        #endregion
    }
}
