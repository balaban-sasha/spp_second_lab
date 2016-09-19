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
            Assert.IsNotNull(weakDelegate.Weak);
        }
        [TestMethod]
        public void TestOnEmptyFunctionAfterCollection()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Action)GetFunction.EmptyFunc);
            GC.Collect();
            Assert.IsNull(weakDelegate.Weak);
        }
        [TestMethod]
        public void TestOnGoodPerson()
        {
            Delegate weakDelegate = new WeakDelegate((Func<string, int, bool, bool>)GetFunction.CheckOnGoodPerson);
            Assert.IsTrue((bool)weakDelegate.DynamicInvoke("Sasha", 20, true));
        }
        [TestMethod]
        public void TestOnBadPerson()
        {
            Delegate weakDelegate = new WeakDelegate((Func<string, int, bool, bool>)GetFunction.CheckOnGoodPerson);
            Assert.IsFalse((bool)weakDelegate.DynamicInvoke("Vita", 20, true));
        }
        [TestMethod]
        public void TestOnGoodVariablesForWords()
        {
            Delegate weakDelegate =new WeakDelegate((Func<string, string,string, string>)GetFunction.GetEasyString);
            Assert.AreEqual((string)weakDelegate.DynamicInvoke("good day", " how are you","?"), "good day how are you?");
        }
        [TestMethod]
        public void TestOnBadVariablesForWords()
        {
            Delegate weakDelegate = new WeakDelegate((Func<string, string,string, string>)GetFunction.GetEasyString);
            Assert.AreNotEqual((string)weakDelegate.DynamicInvoke("good day", " how are you","!"), "good day how are you?");
        }
        [TestMethod]
        public void TestOnGoodVariables()
        {
            Delegate weakDelegate = new WeakDelegate((Func<int, int, int>)GetFunction.GetRuslt);
            Assert.AreEqual((int)weakDelegate.DynamicInvoke(2,3),5);
        }
        [TestMethod]
        public void TestOnBadVariables()
        {
            Delegate weakDelegate = new WeakDelegate((Func<int, int, int>)GetFunction.GetRuslt);
            Assert.AreNotEqual((int)weakDelegate.DynamicInvoke(2, 7), 5);
        }
        [TestMethod]
        public void TestIfWeakReferenceExist()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<int, int, int>)GetFunction.GetRuslt);
            Assert.IsNotNull(weakDelegate.Weak);
        }
        [TestMethod]
        public void TestIfWeakReferenceNotExist()
        {
            WeakDelegate weakDelegate = new WeakDelegate((Func<int,int,int>)GetFunction.GetRuslt);
            GC.Collect();
            Assert.IsNull(weakDelegate.Weak);
        }
    }
}
