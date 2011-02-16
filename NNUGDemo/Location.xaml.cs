using System.Device.Location;
using Microsoft.Phone.Controls;

namespace NNUGDemo
{
    public partial class Location : PhoneApplicationPage
    {
        public Location()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
        }

        private void watcher_PositionChanged(object sender, 
                        GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var location = e.Position.Location;
            var lat = location.Latitude;
            var lon = location.Longitude;
        }
    }
}