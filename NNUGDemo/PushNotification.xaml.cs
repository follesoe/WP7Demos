using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;

namespace NNUGDemo
{
    public partial class PushNotification : PhoneApplicationPage
    {
        public PushNotification()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            var channel = HttpNotificationChannel.Find("TestChannel");

            if (channel == null || channel.ChannelUri == null)
            {
                if(channel != null)
                {
                    channel.Close();
                    channel.Dispose();
                }

                channel = new HttpNotificationChannel("TestChannel");
                channel.ChannelUriUpdated += channel_ChannelUriUpdated;
                channel.ErrorOccurred += channel_ErrorOccurred;
                channel.Open();
            }           
            else
            {
                channel.ErrorOccurred += channel_ErrorOccurred;
                Debug.WriteLine(channel.ChannelUri.AbsoluteUri);
            }

            channel.ShellToastNotificationReceived += channel_ShellToastNotificationReceived;
            
            if(!channel.IsShellToastBound) channel.BindToShellToast();
        }

        private void channel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            Debug.WriteLine("Error: " + e.Message);
        }

        private static void channel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            Debug.WriteLine("Channel opened at: " + e.ChannelUri.AbsoluteUri);
        }

        private void channel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            string message = "";         
            foreach (var text in e.Collection.Values)
            {
                message += text + "\r\n";
            }

            Dispatcher.BeginInvoke(() => output.Text += message);

        }    
    }
}