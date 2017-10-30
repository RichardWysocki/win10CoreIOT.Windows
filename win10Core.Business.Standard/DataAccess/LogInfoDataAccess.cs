using System;
using System.Collections.Generic;
using System.Linq;
using win10Core.Business.Standard.DataAccess.Interface;
using win10Core.Business.Standard.Model;

namespace win10Core.Business.Standard.DataAccess
{
    public class LogInfoDataAccess : ILogInfoDataAccess
    {
        private readonly IDBContext _db;

        public LogInfoDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }

        /// <summary>
        /// Get All LogInfo Records.  Potential Performance Issues if Records grow too big.
        /// </summary>
        /// <returns></returns>
        public IList<LogInfo> Get()
        {
            var getList = _db.LogInfo.ToList();
            return getList;
        }

        /// <summary>
        /// Get One LogInfo Record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LogInfo Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var logInfo = _db.LogInfo.Where(LogInfo => LogInfo.LogInfoId == id).SingleOrDefault();
            if (logInfo == null)
                throw new Exception("Error getting LogInfo record.");
            return logInfo;
        }

        /// <summary>
        /// Insert LogInfo Record.
        /// </summary>
        /// <param name="logInfo"></param>
        /// <returns></returns>
        public LogInfo Insert(LogInfo logInfo)
        {
            //StackTrace stackTrace = new StackTrace();
            //StackFrame stackFrame = stackTrace.GetFrame(1);
            //var methodBase = stackFrame.GetMethod();

            //logInfo.Method = methodBase.Name;

            _db.LogInfo.Add(logInfo);
            _db.SaveChanges();
            return logInfo;

        }
    }
}
