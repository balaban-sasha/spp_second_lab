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
            Func<string, int, bool, bool> f1 = (name, age, active) =>
            {
                if (name == "Jon" && age == 40 && active)
                {
                    return true;
                }
                return false;
            };
            WeakDelegate weakDelegate = new WeakDelegate(f1);
            Delegate d=weakDelegate.GetDelegate();
            Console.WriteLine(d);
            Console.WriteLine(weakDelegate.Weak.DynamicInvoke("Jon",40,true));

        }
    }
}
