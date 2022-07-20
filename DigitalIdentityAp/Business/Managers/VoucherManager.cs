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
    public class VoucherManager : IVoucher
    {
        private SqlServerDb _sqlServerDb;

        public VoucherManager(SqlServerDb sqlServerDb)
        {
            _sqlServerDb = sqlServerDb;
            //_sqlLocation = new SqlLocation();
        }

        public Voucher CreateVoucher(Voucher voucher)
        {
            voucher.Id = Guid.NewGuid();
            voucher.DateCreated = DateTime.Now;
            _sqlServerDb.Vouchers!.Add(voucher!);
            _sqlServerDb.SaveChanges();

            return voucher;
        }

        public void DeleteVoucher(Voucher voucher)
        {
            _sqlServerDb?.Vouchers!.Remove(voucher);
            _sqlServerDb?.SaveChanges();
        }

        public List<Voucher> GetAllVouchers()
        {
            return _sqlServerDb.Vouchers!.ToList();
        }

        public Voucher GetVoucherById(Guid id)
        {
            return _sqlServerDb.Vouchers!.Find(id)!;

        }

        public Voucher UpdateVoucher(Voucher voucher)
        {

            _sqlServerDb.Vouchers!.Update(voucher);
            _sqlServerDb.SaveChanges();
            return voucher;
        }
    }
}
