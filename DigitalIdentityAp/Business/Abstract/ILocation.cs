using DigitalIdentity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Abstract
{
    public interface ILocation
    {
        List<Location> GetAllLocations();
        Location GetLocation(Guid id);
        void DeleteLocation(Location location);
        Location UpdateLocation(Location location);
        Location CreateLocation(Location location);
    }
}
