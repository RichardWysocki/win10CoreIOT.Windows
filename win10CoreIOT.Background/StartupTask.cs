using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;
using ServiceContracts;
using ServiceContracts.Contracts;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace win10CoreIOT.Background
{
    public sealed class StartupTask : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        private ThreadPoolTimer timer;
        private readonly ServiceLayers _serviceCalls;
        private BackgroundWorker worker;

        public StartupTask()
        {
            _serviceCalls = new ServiceLayers(new ServiceSettings("http://localhost:34909/api/"));
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
        }

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
            
        timer = ThreadPoolTimer.CreatePeriodicTimer(Timer_Tick, TimeSpan.FromMinutes(1));
        }

        private void Timer_Tick(ThreadPoolTimer timerTic)
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync();

            Trace.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + "   My App Started");
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _serviceCalls.SendData("LogInfo",
                new LogInformation { Method = "StartupTask: Timer_Tick", Message = "Get All Open Gifts" });
            // Running Thread
            var data = _serviceCalls.GetData<Gift>(@"NotificationApi/GetNewRegisteredGifts/false");
            // Get All Open Gifts Requests
            foreach (var gift in data)
            {
                _serviceCalls.SendData(@"NotificationApi/SomethingElseHere", gift);
            }
            // Send Emal and Update Gifts
        }

    }
}