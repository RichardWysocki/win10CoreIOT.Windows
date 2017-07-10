using System.Collections.Generic;
using System.Data.Entity;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface IDBContext
    {
        
        DbSet<LogError> LogError { get; set; }
        DbSet<LogInfo> LogInfo { get; set; }


        DbSet<Customer> Customer { get; set; }

        DbSet<Parent> Parent { get; set; }

        DbSet<Family> Family { get; set; }

        DbSet<Kid> Kid { get; set; }

        DbSet<Gift> Gift { get; set; }

        void SaveChanges();
    }
}