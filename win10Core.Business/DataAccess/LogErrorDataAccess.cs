using System;
using System.Collections.Generic;
using System.Linq;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class LogErrorDataAccess : ILogErrorDataAccess
    {
        private readonly IDBContext _db;

        public LogErrorDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }

        /// <summary>
        /// Delete ErrorLog record
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var logError = Get(id);
            _db.LogError.Remove(logError);
            _db.SaveChanges();
        }

        /// <summary>
        /// Get List of LogError
        /// </summary>
        /// <returns></returns>
        public IList<LogError> Get()
        {
            var list = _db.LogError.ToList();
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
            var logError = _db.LogError.Where(LogError => LogError.LogErrorId == id).SingleOrDefault();
            if (logError == null)
                throw new Exception("Error getting LogError record.");
            return logError;
        }

        /// <summary>
        ///  Insert LogError Table
        /// </summary>
        /// <param name="logError"></param>
        public LogError Insert(LogError logError)
        {
            _db.LogError.Add(logError);
            _db.SaveChanges();
            return logError;
        }

        /// <summary>
        /// Update ErrorLog Table
        /// </summary>
        /// <param name="logError"></param>
        public bool Update(LogError logError)
        {
            var result = _db.LogError.SingleOrDefault(b => b.LogErrorId == logError.LogErrorId);
            if (result != null)
            {
                result.LogErrorMessage = logError.LogErrorMessage;
                result.LogErrorMethod = logError.LogErrorMethod;
                result.LogErrorSource = logError.LogErrorSource;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
