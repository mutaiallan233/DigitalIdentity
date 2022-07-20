
using DigitalIdentity.Data.Entities;
using DigitalIdentityBl.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalIdentity.Data.Databases.SqlServer.DbContexts
{
    public class SqlServerDb : DbContext
    {
        public SqlServerDb(DbContextOptions<SqlServerDb> options) : base(options)
        {

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=PAULELEGANT\\SQLEXPRESS;database=DigitalIdentityDb;Trusted_Connection=true");
        }*/

        public DbSet<Location>? Locations { get; set; }
       public DbSet<Voucher>? Vouchers { get; set; }
       public DbSet<Vouchee>? Vouchees { get; set; }
    }
}
