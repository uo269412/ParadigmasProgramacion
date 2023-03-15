using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPP.Laboratory.ObjectOrientation.Lab03
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestPush()
        {
            Stack stack5 = new Stack(5);
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, true);
            stack5.Push("A");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("B");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("C");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("D");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("E");
            Assert.AreEqual(stack5.IsFull, true);
            Assert.AreEqual(stack5.IsEmpty, false);
        }


        [TestMethod]
        public void TestPop()
        {
            Stack stack5 = new Stack(5);
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, true);
            stack5.Push("A");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("B");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("C");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("D");
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Push("E");
            Assert.AreEqual(stack5.IsFull, true);
            Assert.AreEqual(stack5.IsEmpty, false);

            stack5.Pop();
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Pop();
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Pop();
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Pop();
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, false);
            stack5.Pop();
            Assert.AreEqual(stack5.IsFull, false);
            Assert.AreEqual(stack5.IsEmpty, true);
        }
    }
}
