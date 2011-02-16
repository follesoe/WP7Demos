using System;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace AppModelDemo
{
    public partial class Temp : PhoneApplicationPage
    {
        public Temp()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(State.ContainsKey("VerticalOffset") &&
                State.ContainsKey("HorizontalOffset"))
            {
                scrollView.ScrollToVerticalOffset(
                    Convert.ToDouble(State["VerticalOffset"]));

                scrollView.ScrollToHorizontalOffset(
                    Convert.ToDouble(State["HorizontalOffset"]));
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            State.Add("VerticalOffset", scrollView.VerticalOffset);
            State.Add("HorizontalOffset", scrollView.HorizontalOffset);
        }
    }
}