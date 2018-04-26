using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Newtonsoft.Json;
using ServiceContracts;
using ServiceContracts.Contracts;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace win10CoreIOT.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static readonly ServiceLayers _serviceCalls = new ServiceLayers(new ServiceSettings("http://localhost:34909/api/"));

        public MainPage()
        {
            this.InitializeComponent();
            //_serviceCalls = new ServiceLayers(new ServiceSettings("http://localhost:34909/api/"));

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetDataAsync();
            Wv1.Navigate(new Uri("http://www.cnn.com"));
        }

        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {

            //Wv1.Navigate(new Uri(Address.Text));
        }

        private static async void GetDataAsync()
        {
            _serviceCalls.SendData("LogInfo",
                new LogInformation { Method = "MainPage: GetDataAsync", Message = "Get All Open Gifts" });
            // Running Thread
            var data = _serviceCalls.GetData<GiftDTO>(@"NotificationApi/GetNewRegisteredGifts/false");
            // Get All Open Gifts Requests
            foreach (var gift in data)
            {
                _serviceCalls.SendData(@"NotificationApi/NotifyParentsofNewGift", gift);
            }

            //List<LogInformation> sampleClass = null ;
            //var getData = new HttpClient();
            ////var response = getData.GetAsync(new Uri("http://localhost:34909/api/LogInfo")).GetResults();
            //var data = await getData.GetAsync(new Uri("http://localhost:34909/api/LogInfo"));
            //var jsonResponse = await data.Content.ReadAsStringAsync();
            //if (jsonResponse != null)
            //    sampleClass = JsonConvert.DeserializeObject<List<LogInformation>>(jsonResponse);
            return;
        }
    }
}
