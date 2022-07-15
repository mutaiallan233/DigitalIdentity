using DigitalIdentityBl.Models;

namespace DigitalIdentity.Data.Databases.Interfaces
{
    public interface ISqlVouchee
    {
        List<Vouchee> GetAllVouchees();
        Vouchee GetVouchee(Guid id);
        void DeleteVouchee(Vouchee vouchee);
        Vouchee UpdateVouchee(Vouchee vouchee);
        Vouchee CreateVouchee(Vouchee vouchee);
    }
}
