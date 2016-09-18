using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spp_lab_2;
using System.Linq.Expressions;

namespace spp_second_lab_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Action<int, int> ex =
        (x, y) => Console.WriteLine("Write {0} and {1}", x, y);
            WeakDelegate weakDelegate = new WeakDelegate(ex);
            weakDelegate.GetDelegate();

        }
    }
}
