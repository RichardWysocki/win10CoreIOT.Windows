using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class DBContext : DbContext, IDBContext
    {

        public DBContext() : base("SchoolContext")
        {
        }

        public DbSet<Customer> customer { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }

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
