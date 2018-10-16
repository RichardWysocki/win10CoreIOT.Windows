using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;

namespace universalwindows.library.Common
{
  
    public enum StorageType
    {
        Roaming, Local, Temporary
    }
    public class StorageHelper<T>
    {
        private ApplicationData appData = ApplicationData.Current;
        public static XmlSerializer _serializer;
        private StorageType storageType;

        public StorageHelper(StorageType StorageType)
        {
            _serializer = new XmlSerializer(typeof(T));
            storageType = StorageType;
        }

        public async void DeleteASync(string fileName)
        {
            fileName = fileName + ".xml";
            StorageFolder folder = GetFolder(storageType);

            var file = await GetFileIfExistsAsync(folder, fileName);
            if (file != null)
            {
                await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
        }

        public async void SaveASync(T obj,string fileName)
        {
            fileName = fileName + ".xml";
            try
            {
                if (obj != null)
                {
                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    StorageFile file = await folder.CreateFileAsync(desiredName: fileName, options: CreationCollisionOption.ReplaceExisting);

                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        _serializer.Serialize(stream, obj);
                    }                    
                }
            }
            catch (Exception)
            {
                if (fileName != "CampusDiningWebSite.xml")
                        throw;
            }
        }

        public async Task<T> LoadASync(string fileName)
        {
            //fileName = fileName; //+ ".xml";
            try
            {
                StorageFile file;
                StorageFolder folder = GetFolder(storageType);
                file = await folder.GetFileAsync(fileName);
                IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read);
                Stream inStream = Task.Run(() => readStream.AsStreamForRead()).Result;
                return (T)_serializer.Deserialize(inStream);
            }
            catch (FileNotFoundException)
            {
                //file not existing is perfectly valid so simply return the default 
                return default(T);
                //throw;
            }
        }

        private StorageFolder GetFolder(StorageType storageType)
        {
            StorageFolder folder;
            switch (storageType)
            {
                case StorageType.Roaming:
                    folder = appData.RoamingFolder;
                    break;
                case StorageType.Local:
                    folder = appData.LocalFolder;
                    break;
                case StorageType.Temporary:
                    folder = appData.TemporaryFolder;
                    break;
                default:
                    throw new Exception(string.Format("Unknown StorageType: {0}", storageType));
            }
            return folder;
        }

        private async Task<StorageFile> GetFileIfExistsAsync(StorageFolder folder, string fileName)
        {
            try
            {
                return await folder.GetFileAsync(fileName);

            }
            catch
            {
                return null;
            }
 }

        //internal void SaveASync(System.Collections.Generic.List<DataGroup> NewDataGroup, string p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
