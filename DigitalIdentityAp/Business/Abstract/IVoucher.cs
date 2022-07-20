
using DigitalIdentity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Abstract
{
    public interface IVoucher
    {
        List<Voucher> GetAllVouchers();
        Voucher GetVoucherById(Guid id);
        Voucher CreateVoucher(Voucher voucher);
        Voucher UpdateVoucher(Voucher voucher);
        void DeleteVoucher(Voucher voucher);
    }
}
