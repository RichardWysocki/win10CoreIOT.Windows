using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win10CoreIOT.Windows
{
    public class LogInformation
    {
        /// <summary>
        /// LogInfoID
        /// </summary>
        public int LogInfoId { get; set; }

        /// <summary>
        /// Method Name from Log
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Message from Log
        /// </summary>
        public string Message { get; set; }
    }
}
