using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactUI;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IsValidChecker isValidCheckerObj = new IsValidChecker();
            Assert.AreEqual(isValidCheckerObj.phoneNumberCheck("7814833367"), true);
        }
    }
}
