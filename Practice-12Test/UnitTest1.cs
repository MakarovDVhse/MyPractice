using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_12;

namespace Practice_12Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            int size = 20;
            Program.Size = size;
            // act
            Program.Ascending();
            Program.Descending();
            Program.NotOrdered();
            Program.AscendingMasSelectionSort();
            Program.DescendingMasSelectionSort();
            Program.NotOrderedMasSelectionSort();
            Program.AscendingMasMergeSort(Program.AscendingMasM, 0, Program.Size - 1);
            Program.DescendingMasMergeSort(Program.DescendingMasM, 0, Program.Size - 1);
            Program.NotOrderedMasMergeSort(Program.NotOrderedMasM, 0, Program.Size - 1);
            // assert
            Assert.AreEqual(Program.NotOrderedMasM.Length, Program.Size);
            Assert.AreEqual(Program.AscendingMasM.Length, Program.Size);
            Assert.AreEqual(Program.DescendingMasM.Length, Program.Size);
            Assert.AreEqual(Program.NotOrderedMasSelecction.Length, Program.Size);
            Assert.AreEqual(Program.AscendingMasSelection.Length, Program.Size);
            Assert.AreEqual(Program.DescendingMasSelection.Length, Program.Size);
        }
    }
}
