using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Devices.Sensors;
using WiimoteAccelerometerProxy;

namespace NNUGDemo.AccelerometerDemo
{

	public static class AccelerometerHelper {
		public static IAccelerometer GetAccelerometer() {

            return new WiimoteAccelerometer();

			// Try to create a default accelerometer
            var sensor = new Accelerometer();
			try {
				sensor.Start();
				sensor.Stop();
			}
			catch (Exception) {
				return new WiimoteAccelerometer();
			}

			return new AccelerometerProxy();
		}
	}


	public class AccelerometerProxy: IAccelerometer {

        private Accelerometer sensor = null;

		public event EventHandler<AccelerometerEventArgs> ReadingChanged;

		public void Start()
		{
		    sensor = new Accelerometer();
			sensor.ReadingChanged += this.HandleSensorReadingChanged;
			sensor.Start();
		}

		public void Stop() {
			if (sensor != null) {
				sensor.Stop();
				sensor.ReadingChanged -= this.HandleSensorReadingChanged;
				sensor = null;
			}
		}

		private void HandleSensorReadingChanged(object sender, AccelerometerReadingEventArgs e) {
			if (this.ReadingChanged != null) {
				var args = new AccelerometerEventArgs() {
					X = e.X,
					Y = e.Y,
                    Z = e.Z
				};

				this.ReadingChanged(this, args);
			}
		}
	}

	public class MouseAccelerometer: IAccelerometer {

		public event EventHandler<AccelerometerEventArgs> ReadingChanged;

		private FrameworkElement target;
		private bool isMouseDown;
		private Point mouseDownLoc;
		private double tolerance = .001;

		public MouseAccelerometer() {
			this.target = (FrameworkElement)Application.Current.RootVisual;
		}

		public void Start() {
			
			this.target.MouseLeftButtonDown += this.HandleMouseDown;
			this.target.MouseMove += this.HandleMouseMove;
			this.target.MouseLeftButtonUp += this.HandleMouseUp;
			this.target.LostMouseCapture += this.HandleLostCapture;
		}

		public void Stop() {

			this.target.MouseLeftButtonDown -= this.HandleMouseDown;
			this.target.MouseMove -= this.HandleMouseMove;
			this.target.MouseLeftButtonUp -= this.HandleMouseUp;
			this.target.LostMouseCapture -= this.HandleLostCapture;

			if (this.isMouseDown) {
				this.target.ReleaseMouseCapture();
				this.isMouseDown = false;
			}
		}

		private void HandleMouseDown(object sender, MouseButtonEventArgs e) {
			if (this.target.CaptureMouse()) {
				this.isMouseDown = true;
				this.mouseDownLoc = e.GetPosition(this.target);
			}
		}

		private void HandleMouseMove(object sender, MouseEventArgs e) {
			if (!this.isMouseDown)
				return;

			Point position = e.GetPosition(this.target);
			if (this.ReadingChanged != null) {
				var args = new AccelerometerEventArgs() {
					X = (position.X - this.mouseDownLoc.X) * this.tolerance,
					Y = -(position.Y - this.mouseDownLoc.Y) * this.tolerance,
				};

				this.ReadingChanged(this, args);
			}
		}

		private void HandleMouseUp(object sender, MouseEventArgs e) {
			this.target.ReleaseMouseCapture();
		}

		private void HandleLostCapture(object sender, EventArgs e) {
			this.isMouseDown = false;
		}
	}
}
