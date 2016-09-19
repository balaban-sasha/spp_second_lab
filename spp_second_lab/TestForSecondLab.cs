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
        public void TestOnEmptyFunctionBeforeCollection()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Action)GetFunction.EmptyFunc);
            Assert.IsNotNull(weakDelegate.GetDelegate());
        }
        [TestMethod]
        public void TestOnEmptyFunctionAfterCollection()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Action)GetFunction.EmptyFunc);
            GC.Collect();
            Assert.IsNull(weakDelegate.GetDelegate());
        }
        [TestMethod]
        public void TestOnGoodPerson()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<string, int, bool, bool>)GetFunction.CheckOnGoodPerson);
            Assert.IsTrue((bool)weakDelegate.GetDelegate().DynamicInvoke("Sasha", 20, true));
        }
        [TestMethod]
        public void TestOnBadPerson()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<string, int, bool, bool>)GetFunction.CheckOnGoodPerson);
            Assert.IsFalse((bool)weakDelegate.GetDelegate().DynamicInvoke("Vita", 20, true));
        }
        [TestMethod]
        public void TestOnGoodVariablesForWords()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<string, string,string, string>)GetFunction.GetEasyString);
            Assert.AreEqual((string)weakDelegate.GetDelegate().DynamicInvoke("good day", " how are you","?"), "good day how are you?");
        }
        [TestMethod]
        public void TestOnBadVariablesForWords()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<string, string,string, string>)GetFunction.GetEasyString);
            Assert.AreNotEqual((string)weakDelegate.GetDelegate().DynamicInvoke("good day", " how are you","!"), "good day how are you?");
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
