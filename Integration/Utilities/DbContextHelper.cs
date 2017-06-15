using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.DataAccess;
using win10Core.Business.Model;

namespace Integration.Utilities
{


    namespace win10Core.Business.DataAccess
    {
        public class DBContextHelper : DbContext
        {

            public DBContextHelper() : base("DBConnection")
            {
            }

            //public DbSet<Customer> Customer { get; set; }
            //public DbSet<LogError> LogError { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }

            public List<T> GetQuery<T>(string sql)
            {
                return base.Database.SqlQuery<T>(sql).ToList();
            }

        }

    }

}
