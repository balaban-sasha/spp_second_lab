using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spp_lab_2;
using System.Linq.Expressions;

namespace spp_second_lab_tests
{
   
    [TestClass]
    public class TestForSecondLab
    {
        private GetFunctionResult GetFunction
        {
            get
            {
                return new GetFunctionResult();
            }
        }
        [TestMethod]
        public void TestOnGoodVariables()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<int, int, int>)GetFunction.GetRuslt);
            Assert.AreEqual((int)weakDelegate.GetDelegate().DynamicInvoke(2,3),5);
        }
        [TestMethod]
        public void TestOnBadVariables()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<int, int, int>)GetFunction.GetRuslt);
            Assert.AreNotEqual((int)weakDelegate.GetDelegate().DynamicInvoke(2, 7), 5);
        }
        [TestMethod]
        public void TestIfWeakReferenceExist()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<int, int, int>)GetFunction.GetRuslt);
            Assert.IsNotNull(weakDelegate.GetDelegate());
        }
        [TestMethod]
        public void TestIfWeakReferenceNotExist()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<int,int,int>)GetFunction.GetRuslt);
            GC.Collect();
            Assert.IsNull(weakDelegate.GetDelegate());
        }
    }
}
