using System.Collections.Generic;
using System.Data.Entity;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface IDBContext
    {
        DbSet<Customer> Customer { get; set; }
        DbSet<LogError> LogError { get; set; }
        DbSet<LogInfo> LogInfo { get; set; }

        void SaveChanges();
        //List<T> GetQuery(string Sql);
    }
}