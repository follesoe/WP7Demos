﻿using Microsoft.Phone.Controls;
using Microsoft.Silverlight.Testing;

namespace UnitTestDemo
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait;

            var settings = UnitTestSystem.CreateDefaultSettings();

            Content = UnitTestSystem.CreateTestPage(settings);
            var imtp = Content as IMobileTestPage;

            if (imtp != null)
            {
                BackKeyPress += (x, xe) => xe.Cancel = imtp.NavigateBack();
            }
        }
    }
}