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
    public class FizzBuzzTest
    {
        [TestMethod, Tag("Unit")]
        public void Three_is_fizz()
        {
            var fizzBuzz = new FizzBuzz();
            var answer = fizzBuzz.Answer(3);

            Assert.AreEqual("fizz", answer);
        }
    }
}
