using System;
using Microsoft.Phone.Shell;

namespace NNUGDemo
{
    public partial class ScheduleTile
    {
        public ScheduleTile()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateShellTileSchedule();
        }

        private ShellTileSchedule shellTileSchedule;

        private void CreateShellTileSchedule()
        {
            shellTileSchedule = new ShellTileSchedule()
            {
                Recurrence = UpdateRecurrence.Interval,
                Interval = UpdateInterval.EveryHour,
                RemoteImageUri =
                new Uri(@"http://mikeo.co.uk/demo/PushNotificationImages/tile.png")
            };
            shellTileSchedule.Start();
        }
    }
}