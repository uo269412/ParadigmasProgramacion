using System;
using delegates;
namespace TPP.Laboratory.Functional.Lab06 {

    class Program {

        static int Addition(int a, int b) {
            return a + b;
        }

        static Func<int, int> CurryedAdd(int a)
        {
            return b => b + a;
        }
        //Curried version of greater than
        static Predicate<int> CurryedGreaterThan(int a)
        {
            return b => a > b;
        }
        static void Main() {
            Console.WriteLine(Addition(1, 2));
            Console.WriteLine(CurryedAdd(1)(2));
            Func<int, int> inc = CurryedAdd(1);

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (var element in numbers)
            {
                Console.WriteLine(inc(element));
            }

            //Parital application of that function with a value
            Predicate<int> gr = CurryedGreaterThan(5);
            foreach (var element in numbers)
            {
                Console.WriteLine(gr(element)); //4 trues, due to 5 being greater than 1, 2, 3 and 4; the rest falses
            }
            //Filter numbers greater than previous value
            var filteredNumbers = numbers.Filter(gr);
            foreach (var element in filteredNumbers)
            {
                Console.WriteLine(element); //Only prints from 1 to 4
            }
        }


}
}
