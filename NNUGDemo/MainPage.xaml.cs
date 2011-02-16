using System;
using System.Windows;

namespace NNUGDemo
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void launchers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Launchers.xaml", UriKind.Relative));
        }

        private void panorama_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PanoramaPage.xaml", UriKind.Relative));
        }

        private void pivot_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage.xaml", UriKind.Relative));
        }

        private void helo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelloWorld.xaml", UriKind.Relative));
        }

        private void storage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/IsolatedStorage.xaml", UriKind.Relative));
        }

        private void push_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PushNotification.xaml", UriKind.Relative));
        }

        private void accell_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AccelerometerDemo/AccelerometerPage.xaml", UriKind.Relative));
        }

        private void tile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScheduleTile.xaml", UriKind.Relative));
        }
    }
}