using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_6;
using System.Collections.Generic;


namespace Practice_6Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            int n = 3;
            Program.N = n;
            // act
            List<double> sequence = new List<double>();
            sequence.Add(1);
            sequence.Add(2);
            sequence.Add(3);
            sequence = Program.RecursiveSequence(sequence);
            Program.CheckTheSequence(sequence);
            // assert
            Assert.AreEqual(sequence.Count, 6);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // arrange
            int n = 3;
            Program.N = n;
            // act
            List<double> sequence = new List<double>();
            sequence.Add(-2);
            sequence.Add(-5);
            sequence.Add(-7);
            sequence = Program.RecursiveSequence(sequence);
            Program.CheckTheSequence(sequence);
            // assert
            Assert.AreEqual(sequence.Count, 6);
        }
        [TestMethod]
        public void TestMethod3()
        {
            // arrange
            int n = 3;
            Program.N = n;
            // act
            List<double> sequence = new List<double>();
            sequence.Add(10);
            sequence.Add(10);
            sequence.Add(10);
            sequence = Program.RecursiveSequence(sequence);
            Program.CheckTheSequence(sequence);
            // assert
            Assert.AreEqual(sequence.Count, 6);
        }
    }
}
