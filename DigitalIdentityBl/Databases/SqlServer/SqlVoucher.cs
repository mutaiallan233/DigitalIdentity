using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Databases.Interfaces;
using DigitalIdentity.Data.Databases.SqlServer.DbContexts;
using DigitalIdentity.Data.Entities;

namespace DigitalIdentity.Data.Databases.SqlServer
{
    public class SqlVoucher : ISqlVoucher
    {
        private SqlServerDb _sqlServerDb;
        private SqlLocation _sqlLocation;

        public SqlVoucher(SqlServerDb sqlServerDb)
        {
            _sqlServerDb = sqlServerDb;
            //_sqlLocation = new SqlLocation();
        }

        public VoucherContext CreateVoucher(VoucherContext voucherContext)
        {
            voucherContext.Id = Guid.NewGuid();
            voucherContext.DateCreated = DateTime.Now;
            _sqlServerDb.Vouchers!.Add(voucherContext!);
            _sqlServerDb.SaveChanges();

            return voucherContext;
        }

        public void DeleteVoucher(VoucherContext voucherContext)
        {
            _sqlServerDb?.Vouchers!.Remove(voucherContext);
            _sqlServerDb?.SaveChanges();
        }

        public List<VoucherContext> GetAllVouchers()
        {
            return _sqlServerDb.Vouchers!.ToList();
        }

        public VoucherContext GetVoucher(Guid id)
        {
            return _sqlServerDb.Vouchers!.Find(id)!;
            
        }

        public VoucherContext UpdateVoucher(VoucherContext voucherContext)
        {
                    
             _sqlServerDb.Vouchers!.Update(voucherContext);
             _sqlServerDb.SaveChanges();
            return voucherContext;
        }
    }
}
