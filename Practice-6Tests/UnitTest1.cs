using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_6;
using System;
using System.Collections.Generic;

namespace Practice_6Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            Program.N = 6;
            // act
            List<double> sequence = new List<double>();
            sequence.Add(1.0);
            sequence.Add(2.0);
            sequence.Add(3.0);
            sequence = Program.RecursiveSequence(sequence);
            Program.CheckTheSequence(sequence);
            // assert
            Assert.AreEqual(sequence.Count, Program.N);
            Assert.AreNotEqual(Console.Out, null);
        }
    }
}
