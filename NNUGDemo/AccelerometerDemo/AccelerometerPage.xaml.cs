using System.Windows.Controls;
using Microsoft.Phone.Controls;
using WiimoteAccelerometerProxy;

namespace NNUGDemo.AccelerometerDemo
{
    public partial class AccelerometerPage : PhoneApplicationPage
    {
        public AccelerometerPage()
        {
            InitializeComponent();
        }

        private IAccelerometer acc;

        private void start_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            acc = AccelerometerHelper.GetAccelerometer();
            acc.ReadingChanged += acc_ReadingChanged;
            acc.Start();
        }

        private void stop_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            acc.Stop();
        }

        private void acc_ReadingChanged(object sender, AccelerometerEventArgs e)
        {
            textX.Text = "X :" + e.X;
            textY.Text = "Y: " + e.Y;
            textZ.Text = "Z: " + e.Z;

            double left = Canvas.GetLeft(ellipse);
            double top = Canvas.GetTop(ellipse);

            double height = canvas1.Height;
            double width = canvas1.Width;

            if(left > 0 && left < width - ellipse.Width)
                Canvas.SetLeft(ellipse, left + (e.X * 2));

            if(top > 0 && top < height - ellipse.Height)
                Canvas.SetTop(ellipse, top + (e.Y * 2));
        }
    }
}