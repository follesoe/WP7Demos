using System;
using System.Net;
using System.Windows;
using System.Threading;
using WiimoteAccelerometerProxy;

namespace NNUGDemo.AccelerometerDemo
{
    public class WiimoteAccelerometer : IAccelerometer
    {
        WebClient client;
        bool stopped = false;
        AccelerometerEventArgs lastArgs;
        string sessionId = Guid.NewGuid().ToString();
        public event EventHandler<AccelerometerEventArgs> ReadingChanged;

        void DoRequest()
        {
            if (!stopped)
                client.DownloadStringAsync(new Uri("http://localhost:4534?session=" + sessionId + "&seed=" + DateTime.Now.Ticks, UriKind.Absolute));
        }

        public void Start()
        {
            stopped = false;
            client = new WebClient();
            client.DownloadStringCompleted += client_DownloadStringCompleted;
            var t = new Thread(WorkerThread);
            t.Start();
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            DoRequest();
            string result = e.Result;
            string[] s = e.Result.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string entry in s)
            {
                ParseSingleEntry(entry);
            }
        }

        public void WorkerThread()
        {
            DoRequest();
            while (stopped == false)
            {
            }
        }

        void ParseSingleEntry(string entry)
        {
            string[] s = entry.Split(',');
            var args = new AccelerometerEventArgs();
            args.X = double.Parse(s[0]);
            args.Y = double.Parse(s[1]);
            args.Z = double.Parse(s[2]);
            if (lastArgs != args && ReadingChanged != null)
            {
                lastArgs = args;
                Application.Current.RootVisual.Dispatcher.BeginInvoke(() => ReadingChanged(this, args));
            }
        }

        public void Stop()
        {
            stopped = true;
        }
    }
}
