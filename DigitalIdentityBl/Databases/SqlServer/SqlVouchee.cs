using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Databases.Interfaces;
using DigitalIdentity.Data.Databases.SqlServer.DbContexts;


namespace DigitalIdentity.Data.Databases.SqlServer
{
    public class SqlVouchee : ISqlVouchee
    {
        private SqlServerDb _sqlServerDb;

        public SqlVouchee(SqlServerDb sqlServerDb)
        {
            _sqlServerDb = sqlServerDb;
        }

        public VoucheeContext CreateVouchee(VoucheeContext voucheeContext)
        {
            voucheeContext.Id = Guid.NewGuid();

            _sqlServerDb.Vouchees!.Add(voucheeContext);
            _sqlServerDb.SaveChanges();

            return voucheeContext;
        }
             
        public string DeleteVouchee(VoucheeContext voucheeContext)
        {
            _sqlServerDb.Vouchees!.Remove(voucheeContext);
            _sqlServerDb.SaveChanges();

            return "Deleted Successfully!";
        }

        public List<VoucheeContext> GetAllVouchees()
        {
            return _sqlServerDb.Vouchees!.ToList();
        }

        public VoucheeContext GetVouchee(Guid id)
        {
            return _sqlServerDb.Vouchees!.Find(id)!;          
        }

        public VoucheeContext UpdateVouchee(VoucheeContext voucheeContext)
        {
            var existingVouchee = _sqlServerDb.Vouchees!.Find(voucheeContext.Id);
            if (existingVouchee != null)
            {
                _sqlServerDb.Vouchees!.Update(voucheeContext);
                _sqlServerDb.SaveChanges();
            }
            return voucheeContext;
        }

        
    }
}
