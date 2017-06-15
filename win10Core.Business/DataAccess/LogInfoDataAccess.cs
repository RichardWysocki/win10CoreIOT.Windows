using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess
{
    public class LogInfoDataAccess : ILogInfoDataAccess
    {
        private readonly IDBContext _db;

        public LogInfoDataAccess(IDBContext dbcontext)
        {
            _db = dbcontext;
        }

        public IList<LogInfo> Get()
        {
            var getList = _db.LogInfo.ToList();
            return getList;
        }

        public LogInfo Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Paramter");
            var logInfo = _db.LogInfo.Where(LogInfo => LogInfo.LogInfoId == id).SingleOrDefault();
            if (logInfo == null)
                throw new Exception("Error getting LogInfo record.");
            return logInfo;
        }

        public void Insert(LogInfo logInfo)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            var methodBase = stackFrame.GetMethod();

            logInfo.Method = methodBase.Name;

            _db.LogInfo.Add(logInfo);
            _db.SaveChanges();
            int id = logInfo.LogInfoId;

        }
    }
}
