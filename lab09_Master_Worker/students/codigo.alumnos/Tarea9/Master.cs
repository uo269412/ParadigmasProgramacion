﻿using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 {

    public class Master {

        private BitcoinValueData[] vector;
        private int numberOfThreads;
        private int fixedValue;

        public Master(BitcoinValueData[] vector, int numberOfThreads, int fixedValue) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            if (fixedValue < 0)
                throw new ArgumentException("The threshold has to be at least positive");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
            this.fixedValue = fixedValue;
        }

        public double ComputeModulus() {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.vector.Length/numberOfThreads;
            for(int i=0; i < this.numberOfThreads; i++)
                workers[i] = new Worker(this.vector, 
                    i*itemsPerThread, 
                    (i<this.numberOfThreads-1) ? (i+1)*itemsPerThread-1: this.vector.Length-1, fixedValue // last one
                    );

            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();
                
            }

            foreach(var thread in threads)
            {
                thread.Join();
            }

            double result = 0;
            foreach (Worker worker in workers) {
                result += worker.Result;
            }
            return result;
        }

    }

}
