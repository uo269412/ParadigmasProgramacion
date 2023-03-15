using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab06 {

    static class FibonacciLazy
    {

        static internal IEnumerable<int> InfiniteFibonacci()
        {
            int first = 1, second = 1;
            while (true)
            {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }

        static internal IEnumerable<int> FibonacciAux(int n)
        {
            int first = 1, second = 1, term = 1;
            while (true)
            {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
                if (term++ == n)
                {
                    yield break;
                }

            }
        }

        static internal int Fibonacci2(int n)
        {
            int i = 0;
            int result = 0;
            foreach (int value in FibonacciAux(n))
            {
                if (++i == n)
                {
                    result = value;
                    break;
                }
                    
            }
            return result;
        }

        static internal int Fibonacci(int n)
        {
            int i = 0;
            int result = 0;
            foreach (int value in InfiniteFibonacci())
            {
                if (++i == n)
                {
                    result = value;
                    break;
                }

            }
            return result;
        }


    }
}
