using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceContracts;
using ServiceContracts.Contracts;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace win10CoreIOT.Background
{
    public sealed class StartupTask : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        private ThreadPoolTimer _timer;
        private readonly ServiceLayers _serviceCalls;
        private BackgroundWorker worker;
        //private readonly Windows.Storage.StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;

        public StartupTask()
        {
            _serviceCalls = new ServiceLayers(new ServiceSettings(GetWebAPISetting()));
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
            _timer = ThreadPoolTimer.CreatePeriodicTimer(Timer_Tick, TimeSpan.FromMinutes(1));
        }

        private void Timer_Tick(ThreadPoolTimer timerTic)
        {

            //var response = ReadTimestamp();
            //Trace.WriteLine(response);
            //var response2 = LoadFromJsonAsync();
            //Trace.WriteLine(response2);
            
            if (!worker.IsBusy)
                worker.RunWorkerAsync();

            Trace.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + "   My App Started"); 
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _serviceCalls.SendData("LogInfo",
                new LogInformation { Method = "StartupTask: Worker_DoWork", Message = "Get All Open Gifts" });
            // Running Thread
            var data = _serviceCalls.GetData<GiftDTO>(@"NotificationApi/GetNewRegisteredGifts/false");
            // Get All Open Gifts Requests
            foreach (var gift in data)
            {
                try
                {
                    _serviceCalls.SendData(@"NotificationApi/NotifyParentsofNewGift", gift);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    _serviceCalls.SendData("LogInfo", new LogInformation { Method = "StartupTask: Worker_DoWork", Message = exception.Message });
                }
                
            }
            // Send Emal and Update Gifts
            _serviceCalls.SendData("LogInfo",
                new LogInformation { Method = "StartupTask: Worker_DoWork", Message = "End." });
        }

        private string GetWebAPISetting()
        {
            try
            {
                //StorageFile sampleFile = await temporaryFolder.GetFileAsync("app.xml");
                //String timestamp = await FileIO.ReadTextAsync(sampleFile);
                string filePath = Path.Combine(Package.Current.InstalledLocation.Path, "app.json");
                using (StreamReader file = File.OpenText(filePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject jObject = (JObject)JToken.ReadFrom(reader);
                    string attrib1 = jObject.GetValue("WebAPI").Value<string>();
                    //jObject.First.ToString();
                    return attrib1;
                }
                // Data is contained in timestamp
            }
            catch (Exception ex)
            {
                // Timestamp not found
                return ex.Message;
            }
        }

        //private static string JsonFile = "app.json";    //your file name

        ////public IList<string> LoadFromJsonAsync()
        ////  {
        ////    List<string> x = null;
        ////    string filePath = Path.Combine(Package.Current.InstalledLocation.Path, "app.json");
        ////    string jsonString = DeserializeFileAsync(filePath).Result;
        ////    if (jsonString != null)
        ////    {
        ////        x = (List<string>)JsonConvert.DeserializeObject(jsonString, typeof(List<string>));
        ////    }

        ////    // return (List<string>)JsonConvert.DeserializeObject(JsonString, typeof(List<string>));
        ////    return x;
        ////}

        //private static async Task<string> DeserializeFileAsync(string fileName)
        //{
        //    try
        //    {
        //        StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        //        return await FileIO.ReadTextAsync(localFile);
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return null;
        //    }
        //}

        


    }
}