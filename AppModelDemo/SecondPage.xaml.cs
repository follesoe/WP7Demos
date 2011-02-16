using System.Diagnostics;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace AppModelDemo
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();

            Debug.WriteLine("SecondPage Constructor");
        }

        private void save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (ViewModel) DataContext;
            StorageHelper.Save("ExpenceReport.xml", viewModel);
            viewModel.IsDirty = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("SecondPage OnNavigatedTo");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Debug.WriteLine("SecondPage OnNavigatedFrom");
        }
    }
}