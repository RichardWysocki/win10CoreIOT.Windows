using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace universalwindows.library.Common
{
    public class LocalIsolatedStorage
    {
        public void SaveClientId(string clientId)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isf.CreateDirectory("Data");
                using (StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("Data\\CientID.txt", FileMode.Create, isf)))
                {
                    sw.WriteLine(clientId);
                }
            }
        }

        public string LoadClientId()
        {
            string clientId;

            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                StreamReader sr;
                try
                {
                    sr = new StreamReader(new IsolatedStorageFileStream("Data\\CientID.txt", FileMode.Open, isf));
                    clientId = sr.ReadLine();
                    //sr.Close();
                }
                catch (Exception)
                {

                    clientId = null;
                }

            }
            return clientId;
        }

    }
}
