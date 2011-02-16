using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace NNUGDemo
{
    public partial class Launchers : PhoneApplicationPage
    {
        public Launchers()
        {
            InitializeComponent();
        }

        private void email_Click(object sender, RoutedEventArgs e)
        {
            var task = new EmailComposeTask();
            task.To = "jonas@follesoe.no";
            task.Body = "Hello NNUG!";
            task.Subject = "Test message";
            task.Show();
        }

        private void emailChooser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmailAddressChooser.xaml", UriKind.Relative));
        }

        private void smsCompose_Click(object sender, RoutedEventArgs e)
        {
            var smsCompose = new SmsComposeTask();
            smsCompose.To = "97706660";
            smsCompose.Body = "Hello NNUG!";
            smsCompose.Show();
        }

        private void makeCall_Click(object sender, RoutedEventArgs e)
        {
            var numberChooser = new PhoneNumberChooserTask();
            numberChooser.Completed += (o, ne) =>
                                           {
                                               var callTask = new PhoneCallTask();
                                               callTask.PhoneNumber = ne.PhoneNumber;
                                               callTask.Show();
                                           };
            numberChooser.Show();
        }

        private void photo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PhotoTasks.xaml", UriKind.Relative));
        }
    }
}