using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;

namespace AppModelDemo
{
    public class StorageHelper
    {
        public static bool FileExists(string filename)
        {
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            return isoStore.FileExists(filename);
        }

        public static void Save<T>(string filename, T item)
        {
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();           
            var serializer = new DataContractSerializer(typeof(T));
            using (var stream = new IsolatedStorageFileStream(filename, FileMode.Create, isoStore))
            {
                serializer.WriteObject(stream, item);
                stream.Close();
            }   
        }

        public static T Load<T>(string filename)
        {
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            var serializer = new DataContractSerializer(typeof(T));
            using (var stream = new IsolatedStorageFileStream(filename, FileMode.Open, isoStore))
            {
                return (T)serializer.ReadObject(stream);
            } 
        }
    }
}
