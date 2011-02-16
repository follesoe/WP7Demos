using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using Microsoft.Phone.Controls;

namespace NNUGDemo
{
    public partial class IsolatedStorage : PhoneApplicationPage
    {
        public IsolatedStorage()
        {
            InitializeComponent();
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            var storage = IsolatedStorageFile.GetUserStoreForApplication();
            if(storage.FileExists("data.txt"))
            {
                using(var sr = new StreamReader(storage.OpenFile("data.txt", FileMode.Open)))
                {
                    text.Text = sr.ReadToEnd();
                }
            }
        }

        private void write_Click(object sender, RoutedEventArgs e)
        {
            var storage = IsolatedStorageFile.GetUserStoreForApplication();
            using (var sr = new StreamWriter(storage.OpenFile("data.txt", FileMode.Create)))
            {
                sr.WriteLine(text.Text);
            }
        }
    }
}