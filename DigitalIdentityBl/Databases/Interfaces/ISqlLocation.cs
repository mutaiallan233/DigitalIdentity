using DigitalIdentity.Data.Entities;

namespace DigitalIdentity.Data.Databases.Interfaces
{
    public interface ISqlLocation
    {
        List<Location> GetAllLocations();
        Location GetLocation(Guid id);
        void DeleteLocation(Location location);
        Location UpdateLocation(Location location);
        Location CreateLocation(Location location);
    }
}
