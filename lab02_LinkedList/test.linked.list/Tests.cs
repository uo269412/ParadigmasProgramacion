using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace linked.list
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddTest()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            Assert.AreEqual("A", listStr.GetElement(0));
            Assert.AreEqual(1, listStr.NumberOfElements);
            listStr.Add("B");
            Assert.AreEqual("B", listStr.GetElement(1));
            Assert.AreEqual(2, listStr.NumberOfElements);
            listStr.Add("C");
            Assert.AreEqual("C", listStr.GetElement(2));
            Assert.AreEqual(3, listStr.NumberOfElements);

            List<int> listInt = new List<int>();
            listInt.Add(4);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(1, listInt.NumberOfElements);
            listInt.Add(5);
            Assert.AreEqual(5, listInt.GetElement(1));
            Assert.AreEqual(2, listInt.NumberOfElements);
            listInt.Add(6);
            Assert.AreEqual(6, listInt.GetElement(2));
            Assert.AreEqual(3, listInt.NumberOfElements);

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            Assert.AreEqual(4.0, listDouble.GetElement(0));
            Assert.AreEqual(1, listDouble.NumberOfElements);
            listDouble.Add(5.0);
            Assert.AreEqual(5.0, listDouble.GetElement(1));
            Assert.AreEqual(2, listDouble.NumberOfElements);
            listDouble.Add(6.0);
            Assert.AreEqual(6.0, listDouble.GetElement(2));
            Assert.AreEqual(3, listDouble.NumberOfElements);
        }

        [TestMethod]
        public void TestRemoveTest()
        {
            //Elimination starting from the start of the list
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual(3, listStr.NumberOfElements);
            listStr.Remove("A");
            Assert.AreEqual("B", listStr.GetElement(0));
            Assert.AreEqual("C", listStr.GetElement(1));
            Assert.AreEqual(2, listStr.NumberOfElements);
            listStr.Remove("B");
            Assert.AreEqual("C", listStr.GetElement(0));
            Assert.AreEqual(1, listStr.NumberOfElements);
            listStr.Remove("C");
            Assert.AreEqual(null, listStr.GetElement(0));
            Assert.AreEqual(0, listStr.NumberOfElements);

            //Elimination starting from the end of the list
            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual(3, listInt.NumberOfElements);
            listInt.Remove(6);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(5, listInt.GetElement(1));
            Assert.AreEqual(2, listInt.NumberOfElements);
            listInt.Remove(5);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(1, listInt.NumberOfElements);
            listInt.Remove(4);
            Assert.AreEqual(0, listInt.GetElement(0));
            Assert.AreEqual(0, listInt.NumberOfElements);

            //Elimination starting from the middle of the list
            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual(3, listDouble.NumberOfElements);

            listDouble.Remove(5.0);
            Assert.AreEqual(4.0, listDouble.GetElement(0));
            Assert.AreEqual(6.0, listDouble.GetElement(1));
            Assert.AreEqual(2, listDouble.NumberOfElements);
            listDouble.Remove(4.0);
            Assert.AreEqual(6.0, listDouble.GetElement(0));
            Assert.AreEqual(1, listDouble.NumberOfElements);
            listDouble.Remove(6.0);
            Assert.AreEqual(0.0, listDouble.GetElement(0));
            Assert.AreEqual(0, listDouble.NumberOfElements);
        }

        [TestMethod]
        public void TestGetElement()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual("A", listStr.GetElement(0));
            Assert.AreEqual("B", listStr.GetElement(1));
            Assert.AreEqual("C", listStr.GetElement(2));

            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(5, listInt.GetElement(1));
            Assert.AreEqual(6, listInt.GetElement(2));

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual(4.0, listDouble.GetElement(0));
            Assert.AreEqual(5.0, listDouble.GetElement(1));
            Assert.AreEqual(6.0, listDouble.GetElement(2));
        }

        [TestMethod]
        public void TestContains()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual(true, listStr.Contains("A"));
            Assert.AreEqual(true, listStr.Contains("B"));
            Assert.AreEqual(true, listStr.Contains("C"));
            Assert.AreEqual(false, listStr.Contains("D"));
            Assert.AreEqual(false, listStr.Contains("E"));
            Assert.AreEqual(false, listStr.Contains("F"));

            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual(true, listInt.Contains(4));
            Assert.AreEqual(true, listInt.Contains(5));
            Assert.AreEqual(true, listInt.Contains(6));
            Assert.AreEqual(false, listInt.Contains(7));
            Assert.AreEqual(false, listInt.Contains(8));
            Assert.AreEqual(false, listInt.Contains(9));

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual(true, listDouble.Contains(4.0));
            Assert.AreEqual(true, listDouble.Contains(5.0));
            Assert.AreEqual(true, listDouble.Contains(6.0));
            Assert.AreEqual(false, listDouble.Contains(7.0));
            Assert.AreEqual(false, listDouble.Contains(8.0));
            Assert.AreEqual(false, listDouble.Contains(9.0));
        }

        [TestMethod]
        public void TestToString()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual("Position : 0 Content: A // Position : 1 Content: B // Position : 2 Content: C // ", listStr.ToString());

            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual("Position : 0 Content: 4 // Position : 1 Content: 5 // Position : 2 Content: 6 // ", listInt.ToString());

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual("Position : 0 Content: 4 // Position : 1 Content: 5 // Position : 2 Content: 6 // ", listDouble.ToString());
        }
    }
}
