using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace WPApplication.Class
{
    public class LocalIsolatedStorage
    {
        public  LocalIsolatedStorage()
        {
            
        }

        public void SaveClientID(string clientID)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isf.CreateDirectory("Data");
                using (StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("Data\\CientID.txt", FileMode.Create, isf)))
                {
                    sw.WriteLine(clientID);
                }
            }
        }

        public string LoadClientID()
        {
            string _clientID = null;

            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(new IsolatedStorageFileStream("Data\\CientID.txt", FileMode.Open, isf));
                    _clientID = sr.ReadLine();
                    //sr.Close();
                }
                catch (Exception)
                {

                    _clientID = null;
                }

            }
            return _clientID;
        }

    }
}
