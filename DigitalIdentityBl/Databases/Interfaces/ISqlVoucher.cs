using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Entities;

namespace DigitalIdentity.Data.Databases.Interfaces
{
    public interface ISqlVoucher
    {
        List<VoucherContext> GetAllVouchers();
        VoucherContext GetVoucher(Guid id);
        void DeleteVoucher(VoucherContext voucherContext);
        VoucherContext UpdateVoucher(VoucherContext voucherContext);
        VoucherContext CreateVoucher(VoucherContext voucherContext);

    }
}
