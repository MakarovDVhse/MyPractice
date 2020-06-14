using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_7;

namespace Practice_7Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange 
            int n = 3;
            int[,] GrayCode = new int[Convert.ToInt32(Math.Pow(2, n)), n];
            // act
            GrayCode = Program.BuildGrayCode(3, GrayCode);
            // assert
            Assert.AreEqual(GrayCode[0, 0] == 0, true);
            Assert.AreEqual(GrayCode.GetLength(1), n);
            Assert.AreEqual(GrayCode.GetLength(0), Convert.ToInt32(Math.Pow(2, n)));
        }
    }
}
