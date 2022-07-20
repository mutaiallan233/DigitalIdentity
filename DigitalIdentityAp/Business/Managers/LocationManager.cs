using DigitalIdentity.App.Business.Abstract;
using DigitalIdentity.Data.Databases.SqlServer.DbContexts;
using DigitalIdentity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Managers
{
    public class LocationManager : ILocation
    {
        private SqlServerDb _sqlServerDb;

        public LocationManager(SqlServerDb sqlServerDb)
        {
            _sqlServerDb = sqlServerDb;
        }

        public Location CreateLocation(Location location)
        {
            location.Id = Guid.NewGuid();

            _sqlServerDb.Locations!.Add(location);
            _sqlServerDb.SaveChanges();
            return location;
        }

        public void DeleteLocation(Location location)
        {
            _sqlServerDb.Locations!.Remove(location);
            _sqlServerDb.SaveChanges();
        }

        public List<Location> GetAllLocations()
        {
            return _sqlServerDb.Locations!.ToList();
        }

        public Location GetLocation(Guid id)
        {
            var location = _sqlServerDb.Locations.Find(id);
            return location!;
        }

        public Location UpdateLocation(Location location)
        {
            var existingLocation = _sqlServerDb.Locations.Find(location.Id);

            if (existingLocation != null)
            {
                existingLocation.Name = location.Name;
                existingLocation.AdministrativeArea = location.AdministrativeArea;
                _sqlServerDb.Locations.Update(existingLocation);
                _sqlServerDb.SaveChanges();
            }
            return location;
        }
    }
}
