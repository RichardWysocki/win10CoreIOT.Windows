using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Contracts;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace win10CoreIOT.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            

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
            List<LogInfo> sampleClass = null ;
            var getData = new HttpClient();
            //var response = getData.GetAsync(new Uri("http://localhost:34909/api/LogInfo")).GetResults();
            var data = await getData.GetAsync(new Uri("http://localhost:34909/api/LogInfo"));
            var jsonResponse = await data.Content.ReadAsStringAsync();
            if (jsonResponse != null)
                sampleClass = JsonConvert.DeserializeObject<List<LogInfo>>(jsonResponse);
            return;
        }
    }
}
