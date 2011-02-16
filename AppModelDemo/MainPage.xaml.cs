using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace AppModelDemo
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Debug.WriteLine("MainPage Constructor");
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            var viewModel = (ViewModel)DataContext;
            if (viewModel.IsDirty)
            {
                if (MessageBox.Show("Er du sikker på at du ønsker å avslutte?", "Ulagrede endringer", MessageBoxButton.OKCancel)
                     == MessageBoxResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("MainPage OnNavigatedTo");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Debug.WriteLine("MainPage OnNavigatedFrom");
        }
    }
}