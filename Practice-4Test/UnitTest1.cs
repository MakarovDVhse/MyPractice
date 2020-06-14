using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pracctice_4;

namespace Practice_4Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            double eps = 0.00001;
            double right = Math.PI / 4;
            double left = 0;
            // act
            bool ok = Program.ChordMethod(eps, 0, right) >= left && Program.ChordMethod(eps, left, right) <= right;
            // assert
            Assert.AreEqual(ok, true);
        }
    }
}
