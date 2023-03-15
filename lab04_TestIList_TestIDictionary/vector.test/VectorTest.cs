using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Collections.Generic
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestAddElementsAndObtainNumberElements()
        {
            IList<string> listS = new List<string>();
            listS.Add("1");
            Assert.AreEqual(1, listS.Count);
            listS.Add("2");
            Assert.AreEqual(2, listS.Count);
            listS.Add("3");
            Assert.AreEqual(3, listS.Count);
            listS.Add("4");
            Assert.AreEqual(4, listS.Count);
            listS.Add("5");
            Assert.AreEqual(5, listS.Count);

            IList<int> listI = new List<int>();
            listI.Add(1);
            Assert.AreEqual(1, listI.Count);
            listI.Add(2);
            Assert.AreEqual(2, listI.Count);
            listI.Add(3);
            Assert.AreEqual(3, listI.Count);
            listI.Add(4);
            Assert.AreEqual(4, listI.Count);
            listI.Add(5);
            Assert.AreEqual(5, listI.Count);
        }

        [TestMethod]
        public void TestGetSetElementInPositionAndIndexOf()
        {
            IList<string> listS = new List<string>();
            listS.Insert(0, "5");
            Assert.AreEqual(0, listS.IndexOf("5"));
            listS.Insert(0, "4");
            Assert.AreEqual(1, listS.IndexOf("5"));
            Assert.AreEqual(0, listS.IndexOf("4"));
            listS.Insert(0, "3");
            Assert.AreEqual(2, listS.IndexOf("5"));
            Assert.AreEqual(1, listS.IndexOf("4"));
            Assert.AreEqual(0, listS.IndexOf("3"));
            listS.Insert(0, "1");
            Assert.AreEqual(3, listS.IndexOf("5"));
            Assert.AreEqual(2, listS.IndexOf("4"));
            Assert.AreEqual(1, listS.IndexOf("3"));
            Assert.AreEqual(0, listS.IndexOf("1"));
            listS.Insert(1, "2");
            Assert.AreEqual(4, listS.IndexOf("5"));
            Assert.AreEqual(3, listS.IndexOf("4"));
            Assert.AreEqual(2, listS.IndexOf("3"));
            Assert.AreEqual(1, listS.IndexOf("2"));
            Assert.AreEqual(0, listS.IndexOf("1"));
            Assert.AreEqual("1", listS[0]);
            Assert.AreEqual("2", listS[1]);
            Assert.AreEqual("3", listS[2]);
            Assert.AreEqual("4", listS[3]);
            Assert.AreEqual("5", listS[4]);

            IList<int> listI = new List<int>();
            listI.Insert(0, 5);
            Assert.AreEqual(0, listI.IndexOf(5));
            listI.Insert(0, 4);
            Assert.AreEqual(1, listI.IndexOf(5));
            Assert.AreEqual(0, listI.IndexOf(4));
            listI.Insert(0, 3);
            Assert.AreEqual(2, listI.IndexOf(5));
            Assert.AreEqual(1, listI.IndexOf(4));
            Assert.AreEqual(0, listI.IndexOf(3));
            listI.Insert(0, 1);
            Assert.AreEqual(3, listI.IndexOf(5));
            Assert.AreEqual(2, listI.IndexOf(4));
            Assert.AreEqual(1, listI.IndexOf(3));
            Assert.AreEqual(0, listI.IndexOf(1));
            listI.Insert(1, 2);
            Assert.AreEqual(4, listI.IndexOf(5));
            Assert.AreEqual(3, listI.IndexOf(4));
            Assert.AreEqual(2, listI.IndexOf(3));
            Assert.AreEqual(1, listI.IndexOf(2));
            Assert.AreEqual(0, listI.IndexOf(1));
            Assert.AreEqual(1, listI[0]);
            Assert.AreEqual(2, listI[1]);
            Assert.AreEqual(3, listI[2]);
            Assert.AreEqual(4, listI[3]);
            Assert.AreEqual(5, listI[4]);
        }

        [TestMethod]
        public void TestConsultElement()
        {
            IList<string> listS = new List<string>();
            Assert.AreEqual(false, listS.Contains("1"));
            listS.Add("1");
            Assert.AreEqual(true, listS.Contains("1"));
            listS.Add("2");
            Assert.AreEqual(true, listS.Contains("2"));
            listS.Add("3");
            Assert.AreEqual(true, listS.Contains("3"));
            listS.Add("4");
            Assert.AreEqual(true, listS.Contains("4"));
            listS.Add("5");
            Assert.AreEqual(true, listS.Contains("5"));
            Assert.AreEqual(false, listS.Contains("6"));

            IList<int> listI = new List<int>();
            Assert.AreEqual(false, listI.Contains(1));
            listI.Add(1);
            Assert.AreEqual(true, listI.Contains(1));
            listI.Add(2);
            Assert.AreEqual(true, listI.Contains(2));
            listI.Add(3);
            Assert.AreEqual(true, listI.Contains(3));
            listI.Add(4);
            Assert.AreEqual(true, listI.Contains(4));
            listI.Add(5);
            Assert.AreEqual(true, listI.Contains(5));
            Assert.AreEqual(false, listI.Contains(6));

        }

        [TestMethod]
        public void TestDeleteFirstOccurence()
        {
            IList<string> listS = new List<string>();
            listS.Add("1");
            Assert.AreEqual(true, listS.Contains("1"));
            listS.Remove("1");
            Assert.AreEqual(false, listS.Contains("1"));
            listS.Add("2");
            Assert.AreEqual(true, listS.Contains("2"));
            listS.Remove("2");
            Assert.AreEqual(false, listS.Contains("2"));
            listS.Add("3");
            Assert.AreEqual(true, listS.Contains("3"));
            listS.Remove("3");
            Assert.AreEqual(false, listS.Contains("3"));
            listS.Add("4");
            Assert.AreEqual(true, listS.Contains("4"));
            listS.Remove("4");
            Assert.AreEqual(false, listS.Contains("4"));
            listS.Add("5");
            Assert.AreEqual(true, listS.Contains("5"));
            listS.Remove("5");
            Assert.AreEqual(false, listS.Contains("5"));

            IList<int> listI = new List<int>();
            listI.Add(1);
            Assert.AreEqual(true, listI.Contains(1));
            listI.Remove(1);
            Assert.AreEqual(false, listI.Contains(1));
            listI.Add(2);
            Assert.AreEqual(true, listI.Contains(2));
            listI.Remove(2);
            Assert.AreEqual(false, listI.Contains(2));
            listI.Add(3);
            Assert.AreEqual(true, listI.Contains(3));
            listI.Remove(3);
            Assert.AreEqual(false, listI.Contains(3));
            listI.Add(4);
            Assert.AreEqual(true, listI.Contains(4));
            listI.Remove(4);
            Assert.AreEqual(false, listI.Contains(4));
            listI.Add(5);
            Assert.AreEqual(true, listI.Contains(5));
            listI.Remove(5);
            Assert.AreEqual(false, listI.Contains(5));
        }

        [TestMethod]
        public void TestIterateForEach()
        {
            IList<string> listS = new List<string>();
            listS.Add("1");
            listS.Add("2");
            listS.Add("3");
            listS.Add("4");
            listS.Add("5");
            Console.WriteLine("FOR EACH TEST");
            foreach (var s in listS)
            {
                Console.WriteLine(s);
            }
        }
    }
}
