using System;
using System.IO;

namespace TPP.Laboratory.Concurrency.Lab09
{

    class Program
    {
        /*
         * This program processes Bitcoin value information obtained from the
         * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
         */
        static void Main(string[] args)
        {

            TextWriter output = new StreamWriter("output.txt");
            var data = Utils.GetBitcoinData();
            foreach (var d in data)
                Console.WriteLine(d);

            int fixedValue = 7000;
            
            Master master = new Master(data, 1, fixedValue);
            DateTime before = DateTime.Now;
            double result = master.ComputeModulus();
            DateTime after = DateTime.Now;
            output.WriteLine("Result with one thread: {0:N2}.", result);
            Console.WriteLine("Result with one thread: {0:N2}.", result);
            output.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            master = new Master(data, 4, fixedValue);
            before = DateTime.Now;
            result = master.ComputeModulus();
            after = DateTime.Now;
            output.WriteLine("Result with 4 threads: {0:N2}.", result);
            Console.WriteLine("Result with 4 threads: {0:N2}.", result);
            output.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            Console.WriteLine("---CONTEXT SWTICHING---");
            const int maxNumberOfThreads = 50;
            ShowLine(Console.Out, "Number of threads", "Ticks", "Result");
            for (int numberOfThreads = 1; numberOfThreads <= maxNumberOfThreads; numberOfThreads++)
            {
                master = new Master(data, numberOfThreads, fixedValue);
                before = DateTime.Now;
                result = master.ComputeModulus();
                after = DateTime.Now;
                ShowLine(Console.Out, numberOfThreads, (after - before).Ticks, result);
                GC.Collect(); // Garbage collection
                GC.WaitForFullGCComplete();
            }
        }

    public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
    {
        short[] vector = new short[numberOfElements];
        Random random = new Random();
        for (int i = 0; i < numberOfElements; i++)
            vector[i] = (short)random.Next(lowest, greatest + 1);
        return vector;
    }


    private const string CSV_SEPARATOR = ";";

        static void ShowLine(TextWriter stream, string numberOfThreadsTitle, string ticksTitle, string resultTitle)
        {
            stream.WriteLine("{0}{3}{1}{3}{2}{3}", numberOfThreadsTitle, ticksTitle, resultTitle, CSV_SEPARATOR);
        }

        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result)
        {
            stream.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }
    }
}
