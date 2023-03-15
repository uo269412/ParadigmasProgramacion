using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Generic
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void TestAddAndCount()
        {
            IDictionary<int, string> dictionaryIS = new Dictionary<int, string>();
            dictionaryIS.Add(0, "A");
            Assert.AreEqual(1, dictionaryIS.Count);
            dictionaryIS.Add(1, "B");
            Assert.AreEqual(2, dictionaryIS.Count);
            dictionaryIS.Add(2, "C");
            Assert.AreEqual(3, dictionaryIS.Count);
            dictionaryIS.Add(3, "D");
            Assert.AreEqual(4, dictionaryIS.Count);
            dictionaryIS.Add(4, "E");
            Assert.AreEqual(5, dictionaryIS.Count);
            dictionaryIS.Add(5, "F");
            Assert.AreEqual(6, dictionaryIS.Count);

            IDictionary<string, int> dictionarySI = new Dictionary<string, int>();
            dictionarySI.Add("A", 0);
            Assert.AreEqual(1, dictionarySI.Count);
            dictionarySI.Add("B", 1);
            Assert.AreEqual(2, dictionarySI.Count);
            dictionarySI.Add("C", 2);
            Assert.AreEqual(3, dictionarySI.Count);
            dictionarySI.Add("D", 3);
            Assert.AreEqual(4, dictionarySI.Count);
            dictionarySI.Add("E", 4);
            Assert.AreEqual(5, dictionarySI.Count);
            dictionarySI.Add("F",5);
            Assert.AreEqual(6, dictionarySI.Count);
        }

        [TestMethod]
        public void TestGetSetValue()
        {
            IDictionary<int, string> dictionaryIS = new Dictionary<int, string>();
            dictionaryIS.Add(0, "A");
            Assert.AreEqual("A", dictionaryIS[0]);
            dictionaryIS.Add(1, "B");
            Assert.AreEqual("B", dictionaryIS[1]);
            dictionaryIS.Add(2, "C");
            Assert.AreEqual("C", dictionaryIS[2]);
            dictionaryIS.Add(3, "D");
            Assert.AreEqual("D", dictionaryIS[3]);
            dictionaryIS.Add(4, "E");
            Assert.AreEqual("E", dictionaryIS[4]);
            dictionaryIS.Add(5, "F");
            Assert.AreEqual("F", dictionaryIS[5]);

            IDictionary<string, int> dictionarySI = new Dictionary<string, int>();
            dictionarySI.Add("A", 0);
            dictionarySI.Add("B", 1);
            dictionarySI.Add("C", 2);
            dictionarySI.Add("D", 3);
            dictionarySI.Add("E", 4);
            dictionarySI.Add("F", 5);
            Assert.AreEqual(0, dictionarySI["A"]);
            Assert.AreEqual(1, dictionarySI["B"]);
            Assert.AreEqual(2, dictionarySI["C"]);
            Assert.AreEqual(3, dictionarySI["D"]);
            Assert.AreEqual(4, dictionarySI["E"]);
            Assert.AreEqual(5, dictionarySI["F"]);

        }

        [TestMethod]
        public void TestDeleteByKey()
        {
            IDictionary<int, string> dictionaryIS = new Dictionary<int, string>();
            Assert.AreEqual(false, dictionaryIS.ContainsKey(0));
            dictionaryIS.Add(0, "A");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(0));
            dictionaryIS.Remove(0);
            Assert.AreEqual(false, dictionaryIS.ContainsKey(0));
            dictionaryIS.Add(1, "B");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(1));
            dictionaryIS.Remove(1);
            Assert.AreEqual(false, dictionaryIS.ContainsKey(1));
            dictionaryIS.Add(2, "C");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(2));
            dictionaryIS.Remove(2);
            Assert.AreEqual(false, dictionaryIS.ContainsKey(2));
            dictionaryIS.Add(3, "D");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(3));
            dictionaryIS.Remove(3);
            Assert.AreEqual(false, dictionaryIS.ContainsKey(3));
            dictionaryIS.Add(4, "E");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(4));
            dictionaryIS.Remove(4);
            Assert.AreEqual(false, dictionaryIS.ContainsKey(4));
            dictionaryIS.Add(5, "F");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(5));
            dictionaryIS.Remove(5);
            Assert.AreEqual(false, dictionaryIS.ContainsKey(5));
            Assert.AreEqual(false, dictionaryIS.ContainsKey(6));

            IDictionary<string, int> dictionarySI = new Dictionary<string, int>();
            Assert.AreEqual(false, dictionarySI.ContainsKey("A"));
            dictionarySI.Add("A", 0);
            Assert.AreEqual(true, dictionarySI.ContainsKey("A"));
            dictionarySI.Remove("A");
            Assert.AreEqual(false, dictionarySI.ContainsKey("A"));
            dictionarySI.Add("B", 1);
            Assert.AreEqual(true, dictionarySI.ContainsKey("B"));
            dictionarySI.Remove("B");
            Assert.AreEqual(false, dictionarySI.ContainsKey("B"));
            dictionarySI.Add("C", 2);
            Assert.AreEqual(true, dictionarySI.ContainsKey("C"));
            dictionarySI.Remove("C");
            Assert.AreEqual(false, dictionarySI.ContainsKey("C"));
            dictionarySI.Add("D", 3);
            Assert.AreEqual(true, dictionarySI.ContainsKey("D"));
            dictionarySI.Remove("D");
            Assert.AreEqual(false, dictionarySI.ContainsKey("D"));
            dictionarySI.Add("E", 4);
            Assert.AreEqual(true, dictionarySI.ContainsKey("E"));
            dictionarySI.Remove("E");
            Assert.AreEqual(false, dictionarySI.ContainsKey("E"));
            dictionarySI.Add("F", 5);
            Assert.AreEqual(true, dictionarySI.ContainsKey("F"));
            dictionarySI.Remove("F");
            Assert.AreEqual(false, dictionarySI.ContainsKey("F"));
            Assert.AreEqual(false, dictionarySI.ContainsKey("G"));
        }

        [TestMethod]
        public void TestExistsKey()
        {
            IDictionary<int, string> dictionaryIS = new Dictionary<int, string>();
            Assert.AreEqual(false, dictionaryIS.ContainsKey(0));
            dictionaryIS.Add(0, "A");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(0));
            dictionaryIS.Add(1, "B");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(1));
            dictionaryIS.Add(2, "C");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(2));
            dictionaryIS.Add(3, "D");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(3));
            dictionaryIS.Add(4, "E");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(4));
            dictionaryIS.Add(5, "F");
            Assert.AreEqual(true, dictionaryIS.ContainsKey(5));
            Assert.AreEqual(false, dictionaryIS.ContainsKey(6));

            IDictionary<string, int> dictionarySI = new Dictionary<string, int>();
            Assert.AreEqual(false, dictionarySI.ContainsKey("A"));
            dictionarySI.Add("A", 0);
            Assert.AreEqual(true, dictionarySI.ContainsKey("A"));
            dictionarySI.Add("B", 1);
            Assert.AreEqual(true, dictionarySI.ContainsKey("B"));
            dictionarySI.Add("C", 2);
            Assert.AreEqual(true, dictionarySI.ContainsKey("C"));
            dictionarySI.Add("D", 3);
            Assert.AreEqual(true, dictionarySI.ContainsKey("D"));
            dictionarySI.Add("E", 4);
            Assert.AreEqual(true, dictionarySI.ContainsKey("E"));
            dictionarySI.Add("F", 5);
            Assert.AreEqual(true, dictionarySI.ContainsKey("F"));
            Assert.AreEqual(false, dictionarySI.ContainsKey("G"));
        }

        [TestMethod]
        public void TestIterate()
        {
            IDictionary<int, string> dictionaryIS = new Dictionary<int, string>();
            dictionaryIS.Add(0, "A");
            dictionaryIS.Add(1, "B");
            dictionaryIS.Add(2, "C");
            dictionaryIS.Add(3, "D");
            dictionaryIS.Add(4, "E");
            dictionaryIS.Add(5, "F");

            Console.WriteLine("FOR EACH TEST");
            foreach (var s in dictionaryIS.Values)
            {
                Console.WriteLine(s);
            }
        }
    }
}
