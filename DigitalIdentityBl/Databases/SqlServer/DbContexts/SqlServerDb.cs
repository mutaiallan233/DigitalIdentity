using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalIdentity.Data.Databases.SqlServer.DbContexts
{
    public class SqlServerDb : DbContext
    {
        public SqlServerDb(DbContextOptions<SqlServerDb> options) : base(options)
        {

        }

       public DbSet<Location>? Locations { get; set; }
       public DbSet<VoucherContext>? Vouchers { get; set; }
       public DbSet<VoucheeContext>? Vouchees { get; set; }
    }
}
