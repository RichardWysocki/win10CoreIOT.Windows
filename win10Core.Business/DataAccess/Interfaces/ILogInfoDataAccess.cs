using System.Collections.Generic;
using win10Core.Business.Model;

namespace win10Core.Business.DataAccess.Interfaces
{
    public interface ILogInfoDataAccess
    {
        /// <summary>
        /// Get All LogInfo Records.  Potential Performance Issues if Records grow too big.
        /// </summary>
        /// <returns></returns>
        IList<LogInfo> Get();
        /// <summary>
        /// Get One LogInfo Record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        LogInfo Get(int id);
        /// <summary>
        /// Insert LogInfo Record.
        /// </summary>
        /// <param name="logInfo"></param>
        /// <returns></returns>
        LogInfo Insert(LogInfo logInfo);

    }
}