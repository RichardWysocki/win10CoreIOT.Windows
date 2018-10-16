using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using universalwindows.library.Models;

namespace universalwindows.library.Common
{
    public class ApplicationUtilities
    {
        public static void CloseApplication()
        {
            Application.Current.Exit();
        }

        public static async Task<List<PersonModel>> GetSavedUsers()
        {
            // ReSharper disable once RedundantAssignment
            var peopleList = new List<PersonModel>();
            var storage = new StorageHelper<List<PersonModel>>(StorageType.Local);
            try
            {
                peopleList = await storage.LoadASync(@"Settings.xml");
            }
            catch (Exception)
            {
                peopleList = null;
            }
            return peopleList;
        }

        public static async Task<AppModel> GetAppSettings()
        {
            // ReSharper disable once RedundantAssignment
            var appModel = new AppModel();
            var storage = new StorageHelper<AppModel>(StorageType.Local);
            try
            {
                appModel = await storage.LoadASync(@"AppSetting.xml");
            }
            catch (Exception)
            {
                appModel = null;
            }
            return appModel;
        }

        public static void ClearList()
        {
            var peopleList = new List<PersonModel>();
            var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);
            storageHelper.SaveASync(peopleList, "Settings");
        }

        public static async Task<string> GetExtractReportData()
        {
            var loadExistingData = await GetSavedUsers();
            return loadExistingData.Aggregate("", (current, model) => current + PrintPersonModel(model));
        }

        private static string PrintPersonModel(PersonModel model)
        {
            return (model.Name + "," + model.Email + "," + model.Phone + Environment.NewLine);
        }

         public static void SaveToIsolatedStorage(Stream imageStream, string fileName)
        {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    myIsolatedStorage.DeleteFile(fileName);
                }

                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(fileName);
                imageStream.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

    }
}
