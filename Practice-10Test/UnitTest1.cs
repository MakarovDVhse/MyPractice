using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_10;

namespace Practice_10Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            Element elem11 = new Element(2, 4);
            Element elem12 = new Element(3, 4);
            Element elem21 = new Element(3, 2);
            Element elem22 = new Element(5, 6);
            // act
            Polinom polinom1 = new Polinom();
            polinom1.Add(elem11);
            polinom1.Add(elem12);
            Polinom polinom2 = new Polinom();
            polinom2.Add(elem21);
            polinom2.Add(elem22);
            Polinom polinom3 = new Polinom();
            polinom3 = Program.Multiplication(polinom1, polinom2, polinom3);
            bool ok = Program.PolinomNothingCheck(polinom1, polinom2);
            polinom3.Sorting();
            // assert
            Assert.AreEqual(polinom3.Count, 4);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // arrange
            string path1 = @"C:\PracticeFiles\Input1.txt";
            string path2 = @"C:\PracticeFiles\Input2.txt";
            // act
            bool ok1 = Program.FileExistance(path1);
            bool ok2 = Program.FileNothingcheck(path1, path2);
            bool ok3 = Program.FileCheckElements(path1, path2);
            bool ok4 = Program.FileCheckRightInput(path1, path2);
            // assert
            Assert.AreEqual(ok1, true);
            Assert.AreEqual(ok2, true);
            Assert.AreEqual(ok3, true);
            Assert.AreEqual(ok4, true);
        }
    }
}
