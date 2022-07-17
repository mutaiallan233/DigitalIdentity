using DigitalIdentity.Data.Databases.Contexts;


namespace DigitalIdentity.Data.Databases.Interfaces
{
    public interface ISqlVouchee
    {
        List<VoucheeContext> GetAllVouchees();
        VoucheeContext GetVouchee(Guid id);
        string DeleteVouchee(VoucheeContext voucheeContext);
        VoucheeContext UpdateVouchee(VoucheeContext voucheeContext);
        VoucheeContext CreateVouchee(VoucheeContext voucheeContext);
    }
}
