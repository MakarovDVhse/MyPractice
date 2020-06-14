using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_5;
using System.Collections.Generic;

namespace Practice_5Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerate()
        {
            // arrange
            int[,] Matrix;
            int n = 5;
            // act
            Matrix = Program.GenerateMatrix(n);
            // assert
            Assert.AreEqual(Matrix.GetLength(0), n);
            Assert.AreEqual(Matrix.GetLength(1), n);
        }
        [TestMethod]
        public void MatrixFind1()
        {
            // arrange
            int n = 3;
            // act
            int[,] Matrix = { { 1, 2, 3}, { 2, 2, 2}, { 3, 3, 3} };
            List<int> list = Program.FindStrings(Matrix, n);
            // assert
            Assert.AreNotEqual(list.Count, 0);
        }
        [TestMethod]
        public void MatrixFind2()
        {
            // arrange
            int n = 3;
            // act
            int[,] Matrix = { { 1, 2, 3 }, { 2, 2, 3 }, { 3, 3, 4 } };
            List<int> list = Program.FindStrings(Matrix, n);
            // assert
            Assert.AreEqual(list.Count, 0);
        }
    }
}
