using Streetcode.DAL.Entities.Locations;
using Streetcode.DAL.Persistence;
using Streetcode.DAL.Repositories.Interfaces.Locations;
using Streetcode.DAL.Repositories.Realizations.Base;

namespace Streetcode.DAL.Repositories.Realizations.Locations
{
    internal class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(StreetcodeDbContext dbContext)
        : base(dbContext)
        {
        }
    }
}
