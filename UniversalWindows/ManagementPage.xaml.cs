using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using universalwindows.library.Common;
using universalwindows.library.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class ManagementPage : Page
    {
        List<PersonModel> _savedUsers = new List<PersonModel>();

        public ManagementPage()
        {
            InitializeComponent();
            FilePath.Visibility = Visibility.Collapsed;
            SaveManageSettings.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TemplatePage));
        }

        private async void SaveUserListButton_Click(object sender, RoutedEventArgs e)
        {
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                CachedFileManager.DeferUpdates(file);
                // write to file
                var contents = ApplicationUtilities.GetExtractReportData();

                await FileIO.WriteTextAsync(file, await contents);
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    textBlock.Text = "File " + file.Name + " was saved.";
                }
                else
                {
                    textBlock.Text = "File " + file.Name + " couldn't be saved.";
                }
            }
            else
            {
               // textBlock.Text = "Operation cancelled.";
            }


        }

        private async void clearListButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to clear the List?");
            dialog.Title = "Continue?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                ApplicationUtilities.ClearList();
                textBlock.Text = "Your List has been cleared. ";
                return;
            }
            textBlock.Text = "";
        }

        private async void WinnerButton_Click(object sender, RoutedEventArgs e)
        {
            var savedUsers = await ApplicationUtilities.GetSavedUsers();
            if (savedUsers == null || savedUsers.Count == 0)
                return;

            Random x = new Random();            
            int winner = x.Next(1,savedUsers.Count+1);
            winnerTextMessage.Text = "And the Winner is..." + Environment.NewLine + savedUsers[winner-1].Name  + Environment.NewLine + savedUsers[winner-1].Email;


        }

        private async void Exitbutton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to Exit TradeShow Wonder?");
            dialog.Title = "Continue?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                ApplicationUtilities.CloseApplication();
            }
            
        }

        private void templatePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TemplatePage));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _savedUsers = await ApplicationUtilities.GetSavedUsers();
            // ReSharper disable once ConstantNullCoalescingCondition
            textBlock.Text = "Current Users: " + _savedUsers?.Count ?? "0";
        }

        private async void CompanyImage_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker open = new FileOpenPicker();
            open.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            open.ViewMode = PickerViewMode.Thumbnail;
            // Filter to include a sample subset of file types
            open.FileTypeFilter.Clear();
            open.FileTypeFilter.Add(".png");
            //open.FileTypeFilter.Add(".jpeg");
            //open.FileTypeFilter.Add(".jpg");
            StorageFile file = await open.PickSingleFileAsync();
            if (file != null)
            {
                FilePath.Text = file.Name;
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.DecodePixelHeight = 300;
                    bitmapImage.DecodePixelWidth = 300;
                    await bitmapImage.SetSourceAsync(fileStream);
                    image.Source = bitmapImage;
                }
                try
                {
                    await file.CopyAsync(ApplicationData.Current.LocalFolder);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    saveManageSettings(FilePath.Text);
                }

            }
        }

        private void SaveManageSettings_Click(object sender, RoutedEventArgs e)
        {
            var appSettings = new AppModel("12345",FilePath.Text);
            var storageHelper = new StorageHelper<AppModel>(StorageType.Local);
            storageHelper.SaveASync(appSettings, "AppSetting");
        }


        private void saveManageSettings(string file)
        {
            var appSettings = new AppModel("12345", file);
            var storageHelper = new StorageHelper<AppModel>(StorageType.Local);
            storageHelper.SaveASync(appSettings, "AppSetting");
        }
    }
}
