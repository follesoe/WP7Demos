using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace NNUGDemo
{
    public partial class EmailAddressChooser : PhoneApplicationPage
    {
        public EmailAddressChooser()
        {
            InitializeComponent();
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            var emailChooser = new EmailAddressChooserTask();
            emailChooser.Completed += emailChooser_Completed;
            emailChooser.Show();
        }

        private void emailChooser_Completed(object sender, EmailResult e)
        {
            if(e.TaskResult == TaskResult.OK)
                email.Text = e.Email;
        }
    }
}