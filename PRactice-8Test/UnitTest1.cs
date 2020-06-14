using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_8;

namespace PRactice_8Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            int[,] Matrix;
            int[,] VerticesMatrix;
            int clique = 1;
            // act
            Matrix = Program.TestGenerator();
            VerticesMatrix = Program.MakeVerticesMatrix(Matrix);
            bool ok = Program.CliqueCheck(Matrix, clique);
            Program.CliqueFind(clique, VerticesMatrix);
            // assert
            Assert.AreEqual(Matrix.GetLength(0), VerticesMatrix.GetLength(0));
            Assert.AreEqual(Matrix.GetLength(0), VerticesMatrix.GetLength(1));
            Assert.AreEqual(ok, true);
            Assert.AreNotEqual(Console.Out, null);
        }
    }
}
