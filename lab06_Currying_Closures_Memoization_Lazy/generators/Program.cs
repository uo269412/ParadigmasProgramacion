using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Ejemplo de memorización
    /// </summary>
    class Program {

        static void Main(string[] args) {
            const int fibonacciTerm = 40;
            int result;

            var chrono = new Stopwatch();
            chrono.Start();
            result = FibonacciLazy.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long firstCallFibonacciLazy = chrono.ElapsedTicks;
            Console.WriteLine("FIBONACCI LAZY. First invocation in {0:N} ticks. Number of terms: {1}. Result: {2}.", firstCallFibonacciLazy, fibonacciTerm, result);

            chrono.Restart();
            result = FibonacciLazy.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long secondCallFibonacciLazy = chrono.ElapsedTicks;
            Console.WriteLine("FIBONACCI LAZY. Second invocation in {0:N} ticks. Number of terms: {1}. Result: {2}.", secondCallFibonacciLazy, fibonacciTerm, result);

            chrono.Restart();
            result = FibonacciEager.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long firstCallFibonacciEager = chrono.ElapsedTicks;
            Console.WriteLine("FIBONACCI EAGER. Second invocation in {0:N} ticks. Number of terms: {1}. Result: {2}.", firstCallFibonacciEager, fibonacciTerm, result);

            chrono.Restart();
            result = FibonacciEager.Fibonacci(fibonacciTerm);
            chrono.Stop();
            long secondCallFibonacciEager = chrono.ElapsedTicks;
            Console.WriteLine("FIBONACCI EAGER. Second invocation in {0:N} ticks. Number of terms: {1}. Result: {2}.", secondCallFibonacciEager, fibonacciTerm, result);
        }


    }
}
