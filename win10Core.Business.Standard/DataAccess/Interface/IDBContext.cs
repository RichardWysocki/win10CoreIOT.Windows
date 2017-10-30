using Microsoft.EntityFrameworkCore;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess.Interface
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