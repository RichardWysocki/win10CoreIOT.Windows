using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using universalwindows.library.Common;
using universalwindows.library.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.WebViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfigurationsPage : Page
    {
        public ConfigurationsPage()
        {
            this.InitializeComponent();
        }

        private async void _saveWebsiteURL_Click(object sender, RoutedEventArgs e)
        {
            ////var person = new PersonModel(Name.Text, Email.Text, Phone.Text);
            //var validation = new PersonBusiness();
            //var validate = validation.ValidatePerson(person);

            //if (validate.isValid)
            //{
                var loadExistingData = await ApplicationUtilities.GetConfigurations();
                var storageHelper = new StorageHelper<ConfigurationsModel>(StorageType.Local);

                if (loadExistingData == null)
                {
                //var peopleList = new List<PersonModel> { person };
                var configurations = new ConfigurationsModel
                {
                    WebsiteURL = _websiteURL.Text
                };
                storageHelper.SaveASync(configurations, "Configurations");
                }
                else
                {
                //loadExistingData.Add(person);
                loadExistingData.WebsiteURL = _websiteURL.Text;
                storageHelper.SaveASync(loadExistingData, "Configurations");
                }
                //ErrorText.Text = "Saved...";
                //ClearUserEntry();
            //}
            //else
            //{
            //    ErrorText.Text = validate.errorMessage;
            //}
        }

        private void _back_Click(object sender, RoutedEventArgs e)
        {
            //Go 
            Frame.Navigate(typeof(ManagementPage));

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var loadExistingData = await ApplicationUtilities.GetConfigurations();
            if (loadExistingData == null)
                _websiteURL.Text = "https://www.RichardWysocki.com";
            else
                _websiteURL.Text = loadExistingData.WebsiteURL;
        }
    }
}
