using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using universalwindows.library.Common;
using universalwindows.library.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class TemplatePage : Page
    {
        AppModel _savedAppSettings = new AppModel();

        public TemplatePage()
        {
            InitializeComponent();
        }


        private void PhoneNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private void emailAddressTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private void firstNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        public void ClearUserEntry()
        {
            firstNameTextBox.Text = "";
            emailAddressTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
        }

        public void ClearErrorMessage()
        {
            ErrorMessageTextBlock.Text = "";
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
            saveButton.Focus(FocusState.Keyboard);
            _savedAppSettings = await ApplicationUtilities.GetAppSettings();
            if (_savedAppSettings != null && _savedAppSettings.CompanyImage.Length > 0)
            {
                Uri uri = new Uri(@"ms-appdata:///local/" + _savedAppSettings.CompanyImage, UriKind.Absolute);
                try
                {
                    var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                    using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
                    {
                        BitmapImage bitmapImage = new BitmapImage
                        {
                            DecodePixelHeight = 300,
                            DecodePixelWidth = 300
                        };
                        await bitmapImage.SetSourceAsync(fileStream);
                        CompanyImage.Source = bitmapImage;
                    }
                }
                catch (Exception)
                {
                }

            }
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var person = new PersonModel(firstNameTextBox.Text, emailAddressTextBox.Text, PhoneNumberTextBox.Text);
            var validation = new PersonBusiness();
            var validate = validation.ValidatePerson(person);

            if (validate.IsValid)
            {
                var loadExistingData = await ApplicationUtilities.GetSavedUsers();
                var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);

                if (loadExistingData == null)
                {
                    var peopleList = new List<PersonModel> { person };
                    storageHelper.SaveASync(peopleList, "Settings");
                }
                else
                {
                    loadExistingData.Add(person);
                    storageHelper.SaveASync(loadExistingData, "Settings");
                }
                ErrorMessageTextBlock.Text = "Saved...";
                ClearUserEntry();
            }
            else
            {
                ErrorMessageTextBlock.Text = validate.ErrorMessage;
            }
            saveButton.Focus(FocusState.Keyboard);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void CompanyImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
