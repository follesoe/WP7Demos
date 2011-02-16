using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiimoteAccelerometerProxy
{
    public class AccelerometerEventArgs : EventArgs
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public interface IAccelerometer
    {

        event EventHandler<AccelerometerEventArgs> ReadingChanged;

        void Start();
        void Stop();
    }
}
