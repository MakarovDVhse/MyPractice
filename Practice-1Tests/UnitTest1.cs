using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_3;

namespace Practice_3Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPoint1()
        {
            // arrange
            double x = 0;
            double y = 0;
            // act
            bool ok = Practice_3.Program.Predicate(x, y);
            // assert
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void TestPoint2()
        {
            // arrange
            double x = -1;
            double y = 1;
            // act
            bool ok = Practice_3.Program.Predicate(x, y);
            // assert
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void TestPoint3()
        {
            // arrange
            double x = -2;
            double y = -1;
            // act
            bool ok = Practice_3.Program.Predicate(x, y);
            // assert
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void TestPoint4()
        {
            // arrange
            double x = 1;
            double y = 0;
            // act
            bool ok = Practice_3.Program.Predicate(x, y);
            // assert
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void TestPoint5()
        {
            // arrange
            double x = -1;
            double y = 0;
            // act
            bool ok = Practice_3.Program.Predicate(x, y);
            // assert
            Assert.AreEqual(ok, true);
        }
        [TestMethod]
        public void TestPoint6()
        {
            // arrange
            double x = 2;
            double y = 3;
            // act
            bool ok = Practice_3.Program.Predicate(x, y);
            // assert
            Assert.AreEqual(ok, false);
        }
    }
}
