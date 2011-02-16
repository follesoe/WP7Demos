using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PushTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void push_Click(object sender, RoutedEventArgs e)
        {
            string toastMessage =  string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                    "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                       "<wp:Toast>" +
                                          "<wp:Text1>{0}</wp:Text1>" +
                                          "<wp:Text2>{1}</wp:Text2>" +
                                       "</wp:Toast>" +
                                    "</wp:Notification>", text1.Text, text2.Text);

            // The URI that the Push Notification Service returns to the Push Client when creating a notification channel.
            string subscriptionUri = channelUrl.Text;
            var sendNotificationRequest = (HttpWebRequest)WebRequest.Create(subscriptionUri);

            // HTTP POST is the only allowed method to send the notification.
            sendNotificationRequest.Method = "POST";

            // The optional custom header X-MessageID uniquely identifies a notification message. If it is present, the // same value is returned in the notification response. It must be a string that contains a UUID.
            sendNotificationRequest.ContentType = "text/xml";
            sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "toast");
            sendNotificationRequest.Headers.Add("X-NotificationClass", "2");
            
            // Sets the web request content length.
            sendNotificationRequest.ContentLength = toastMessage.Length;

            // Sets the notification payload to send.
            byte[] notificationMessage = new UTF8Encoding().GetBytes(toastMessage);

            using (Stream requestStream = sendNotificationRequest.GetRequestStream())
            {
               requestStream.Write(notificationMessage, 0, notificationMessage.Length);
            }

            // Sends the notification and gets the response.
            var response = (HttpWebResponse)sendNotificationRequest.GetResponse();
            string notificationStatus = response.Headers["X-NotificationStatus"];
            string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
            string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

        }
    }
}
