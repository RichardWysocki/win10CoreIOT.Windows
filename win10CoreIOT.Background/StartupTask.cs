﻿using System;
using System.Diagnostics;
using System.Globalization;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;
using ServiceContracts;
using ServiceContracts.NewFolder;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace win10CoreIOT.Background
{
    public sealed class StartupTask : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        private ThreadPoolTimer timer;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //

            _deferral = taskInstance.GetDeferral();

            timer = ThreadPoolTimer.CreatePeriodicTimer(Timer_Tick,
                TimeSpan.FromMinutes(1));
        }

        private void Timer_Tick(ThreadPoolTimer timer)
        {
            var x = new ServiceContracts.NewFolder.ServiceLayers(
                new ServiceSettings("http://localhost:34909/api/"));
            x.SendData("LogInfo", new LogInformation { Method = "SendData", Message = "MyFirstMessage" });

            Trace.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + "   My App Started");
        }
    }
}
