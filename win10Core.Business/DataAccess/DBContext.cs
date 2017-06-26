using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class DBContext : DbContext, IDBContext
    {

        public DBContext() : base("DBConnection")
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<LogError> LogError { get; set; }
        public DbSet<LogInfo> LogInfo { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        void IDBContext.SaveChanges()
        {
            base.SaveChanges();
        }


    }

}
