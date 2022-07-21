using DigitalIdentityBl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Abstract
{
    public interface IVouchee
    {
        List<Vouchee> GetAllVouchees();
        Vouchee GetVouchee(Guid id);
        void DeleteVouchee(Vouchee vouchee);
        Vouchee UpdateVouchee(Vouchee vouchee);
        Vouchee CreateVouchee(Vouchee vouchee);
        int GetLastVouchee();
    }
}
