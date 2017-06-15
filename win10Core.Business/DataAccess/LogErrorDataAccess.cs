using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class LogErrorDataAccess : ILogErrorDataAccess
    {
        private readonly IDBContext db;

        public LogErrorDataAccess(IDBContext dbcontext)
        {
            db = dbcontext;
        }

        /// <summary>
        /// Delete ErrorLog record
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var logError = Get(id);
            db.LogError.Remove(logError);
            db.SaveChanges();

            

        }

        /// <summary>
        /// Get List of LogError
        /// </summary>
        /// <returns></returns>
        public IList<LogError> Get()
        {
            var list = db.LogError.ToList();
            return list;
        }

        /// <summary>
        /// Get ErrorLog Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LogError Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter"); 
            var logError = db.LogError.Where(LogError => LogError.LogErrorId == id).SingleOrDefault();
            if (logError == null)
                throw new Exception("Error getting LogError record.");
            return logError;
        }

        /// <summary>
        ///  Insert LogError Table
        /// </summary>
        /// <param name="logError"></param>
        public void Insert(LogError logError)
        {
            var data = db.LogError.Add(logError);
            db.SaveChanges();
        }

        /// <summary>
        /// Update ErrorLog Table
        /// </summary>
        /// <param name="logError"></param>
        public void Update(LogError logError)
        {
            var result = db.LogError.SingleOrDefault(b => b.LogErrorId == logError.LogErrorId);
            if (result != null)
            {
                result.LogErrorMessage = logError.LogErrorMessage;
                result.LogErrorMethod = logError.LogErrorMethod;
                result.LogErrorSource = logError.LogErrorSource;
            }
            db.SaveChanges();
        }


        //public List<Customer> Mytest()
        //{
        //    var response = db.GetQuery<Customer>("test");
        //    return response;
        //}
    }
}
