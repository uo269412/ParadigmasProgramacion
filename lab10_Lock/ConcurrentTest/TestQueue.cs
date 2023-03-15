using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using concurrent.queue;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConcurrentTest
{
    [TestClass]
    public class TestQueue
    {
        [TestMethod]
        public void TestNumberOfElements()
        {
            ConcurrentQueue<String> stringQ = new ConcurrentQueue<string>();

            var tasks = new List<Task>();
            String[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    stringQ.Enqueue(alphabet[i]);

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(26, stringQ.NumberOfElements);

            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    stringQ.Dequeue();

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(0, stringQ.NumberOfElements);
        }
    


        [TestMethod]
        public void TestIsEmpty()
        {
            ConcurrentQueue<String> stringQ = new ConcurrentQueue<string>();
            var tasks = new List<Task>();
            String[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            Assert.IsTrue(stringQ.IsEmpty());
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    stringQ.Enqueue(alphabet[i]);

                }
            }));

            Task.WaitAll(tasks.ToArray());

            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    stringQ.Dequeue();

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.IsTrue(stringQ.IsEmpty());
        }


        [TestMethod]
        public void TestEnqueue()
        {
            ConcurrentQueue<String> stringQ = new ConcurrentQueue<string>();
            var tasks = new List<Task>();
            String[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length / 2; i++)
                {
                    stringQ.Enqueue(alphabet[i]);

                }
            }));

            tasks.Add(Task.Run(() =>
            {
                for (int i = alphabet.Length / 2; i < alphabet.Length; i++)
                {
                    stringQ.Enqueue(alphabet[i]);

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(stringQ.NumberOfElements, 26);
        }


        [TestMethod]
        public void TestDequeue()
        {
            ConcurrentQueue<String> stringQ = new ConcurrentQueue<string>();
            var tasks = new List<Task>();
            String[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    stringQ.Enqueue(alphabet[i]);

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(stringQ.NumberOfElements, 26);

            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length / 2; i++)
                {
                    stringQ.Dequeue();

                }
            }));

            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length / 2; i++)
                {
                    stringQ.Dequeue();

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.IsTrue(stringQ.IsEmpty());
        }


        [TestMethod]
        public void TestPeek()
        {

            ConcurrentQueue<String> stringQ = new ConcurrentQueue<string>();
            var tasks = new List<Task>();
            String[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    stringQ.Enqueue(alphabet[i]);

                }
            }));

            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(stringQ.NumberOfElements, 26);
            Assert.AreEqual(stringQ.Peek(), "A");
            Assert.AreEqual(stringQ.NumberOfElements, 26);

        }

    }
}
