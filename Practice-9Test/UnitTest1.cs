using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_9;

namespace Practice_9Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            int n = 3;
            DoublePoint list = new DoublePoint();
            // act
            list = DoublePoint.GenerateList(n);
            DoublePoint.ShowList(list);
            int difference = DoublePoint.FindDifference(list);
            // assert
            Assert.AreNotEqual(list.data, null);
            Assert.AreNotEqual(Console.Out, null);
            Assert.AreNotEqual(difference, null);
        }
    }
}
