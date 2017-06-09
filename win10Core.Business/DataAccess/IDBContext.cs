using System.Data.Entity;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public interface IDBContext
    {
        DbSet<Customer> customer { get; set; }

        void SaveChanges();
    }
}