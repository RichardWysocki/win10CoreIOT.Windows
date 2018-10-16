using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using UniversalWindows.Model;

namespace UniversalWindows.Common
{
    public class ApplicationUtilities
    {
        public static void CloseApplication()
        {
            Application.Current.Exit();
        }

        public static async Task<List<PersonModel>> GetSavedUsers()
        {
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

    }
}
