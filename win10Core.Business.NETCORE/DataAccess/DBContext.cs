using Microsoft.EntityFrameworkCore;
using win10Core.Business.DataAccess.Interfaces;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class DBContext : DbContext, IDBContext
    {

       // public DBContext() /*: base(new DbContextOptions)*/
        public DBContext(DbContextOptions<DBContext> options) : base(options)
         {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<LogError> LogError { get; set; }
        public DbSet<LogInfo> LogInfo { get; set; }
        public DbSet<Kid> Kid { get; set; }
        public DbSet<Gift> Gift { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        void IDBContext.SaveChanges()
        {
            base.SaveChanges();
        }


    }

}
