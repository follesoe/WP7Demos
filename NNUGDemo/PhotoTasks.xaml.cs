using System.Windows;
using Microsoft.Phone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace NNUGDemo
{
    public partial class PhotoTasks : PhoneApplicationPage
    {
        public PhotoTasks()
        {
            InitializeComponent();
        }

        private void camera_Click(object sender, RoutedEventArgs e)
        {
            var cameraTask = new CameraCaptureTask();
            cameraTask.Completed += (o, ce) => { image.Source = PictureDecoder.DecodeJpeg(ce.ChosenPhoto); };
            cameraTask.Show();
        }

        private void library_Click(object sender, RoutedEventArgs e)
        {
            var chooser = new PhotoChooserTask();
            chooser.Completed += (o, ce) => { image.Source = PictureDecoder.DecodeJpeg(ce.ChosenPhoto); };
            chooser.Show();
        }
    }
}