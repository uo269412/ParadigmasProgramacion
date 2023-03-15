using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPP.Laboratory.Concurrency.Lab09
{
    [TestClass]
    public class UnitTest1
    {
        private BitcoinValueData[] data = Utils.GetBitcoinData();
        private int fixedValue = 7000;

        private double Compute()
        {
            long result = 0;
            foreach(var element in data)
            {
                if (element.Value > fixedValue)
                {
                    result++;
                }
            }
            return result;
        } 

        [TestMethod]
        public void TestSequential()
        {
            //this.data = Utils.GetBitcoinData();
            Master master = new Master(data, 1, fixedValue);
            Assert.AreEqual(master.ComputeModulus(), this.Compute());
        }

        [TestMethod]
        public void TestConcurrent()
        {
            //this.data = Utils.GetBitcoinData();
            Master master = new Master(data, 4, fixedValue);
            Assert.AreEqual(master.ComputeModulus(), this.Compute());
        }
    }
}
