using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDemo
{
    [TestClass]
    public class AirportsTest : SilverlightTest
    {
        [TestMethod, Asynchronous, Tag("Service")]
        public void Can_get_airport_names()
        {
            var airports = new AirportService();

            string result = string.Empty;
            
            EnqueueCallback(() => airports.GetAirports(content => result = content));
            EnqueueConditional(() => !string.IsNullOrEmpty(result));
            EnqueueCallback(() => Assert.IsTrue(result.Contains("OSL")));
            EnqueueTestComplete();
        }

    }
}
