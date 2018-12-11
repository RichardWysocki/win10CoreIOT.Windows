using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniversalWindows;
using UWP.WebViewer.Common;
using PersonModel = UWP.WebViewer.Model.PersonModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.WebViewer
{
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
              
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var person = new PersonModel(Name.Text, Email.Text, Phone.Text);
            var validation = new PersonBusiness();
            var validate = validation.ValidatePerson(person);

            if (validate.isValid)
            {
                var loadExistingData = await ApplicationUtilities.GetSavedUsers();
                var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);

                if (loadExistingData == null)
                {
                    var peopleList = new List<PersonModel> {person};
                    storageHelper.SaveASync(peopleList, "Settings");
                }
                else
                {
                    loadExistingData.Add(person);
                    storageHelper.SaveASync(loadExistingData, "Settings");
                }
                ErrorText.Text = "Saved...";
                ClearUserEntry();
            }
            else
            {
                ErrorText.Text = validate.errorMessage;                 
            }
                
        }

        private void OnloadedComplete(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
        }

        private void NavToManagement_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        public void ClearUserEntry()
        {
            Name.Text = "";
            Email.Text = "";
            Phone.Text = "";
        }

        public void ClearErrorMessage()
        {
            ErrorText.Text = "";
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private void Phone_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }
    }
}
