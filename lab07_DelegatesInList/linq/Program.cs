using System.Collections.Generic;
using System;
using System.Linq;

namespace TPP.Laboratory.Functional.Lab07 {

    class Program {

        static void Main() {
            IEnumerable<int> integers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var list = integers.Map(x => { Console.WriteLine(x); return x; });

            //foreach(var e in list)
            //{ }

            list.First();
            list.Skip(5);
            list.Take(5);
            list.Skip(2).Take(3).First();
            list.Skip(2).Take(3).Last();
        }
    }
}
