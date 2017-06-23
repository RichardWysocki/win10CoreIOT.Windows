using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win10Core.Business.Engine
{
    public interface ILogEngine
    {
        void LogInfo(string method, string message);

        void LogError(string source, string method, string message);
    }
}
