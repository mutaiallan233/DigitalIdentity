using DigitalIdentity.App.Business.Abstract;
using DigitalIdentity.Data.Databases.SqlServer.DbContexts;
using DigitalIdentityBl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Managers
{
    public class VoucheeManager : IVouchee
    {
        private SqlServerDb _sqlServerDb;

        public VoucheeManager(SqlServerDb sqlServerDb)
        {
            _sqlServerDb = sqlServerDb;
        }

        public Vouchee CreateVouchee(Vouchee vouchee)
        {
            vouchee.Id = Guid.NewGuid();
            vouchee.DateCreated = DateTime.Now;
            _sqlServerDb.Vouchees!.Add(vouchee);
            _sqlServerDb.SaveChanges();

            return vouchee;
        }

        public void DeleteVouchee(Vouchee vouchee)
        {
            _sqlServerDb.Vouchees!.Remove(vouchee);
            _sqlServerDb.SaveChanges();

            //return "Deleted Successfully!";
        }

        public List<Vouchee> GetAllVouchees()
        {
            return _sqlServerDb.Vouchees!.ToList();
        }

        public Vouchee GetVouchee(Guid id)
        {
            return _sqlServerDb.Vouchees!.Find(id)!;
        }

        public Vouchee UpdateVouchee(Vouchee vouchee)
        {
            var existingVouchee = _sqlServerDb.Vouchees!.Find(vouchee.Id);
            if (existingVouchee != null)
            {
                _sqlServerDb.Vouchees!.Update(vouchee);
                _sqlServerDb.SaveChanges();
            }
            return vouchee;
        }

    }
}
