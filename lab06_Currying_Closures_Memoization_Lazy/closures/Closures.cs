using System;
using System.Collections.Generic;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Try to guess the behavior of this program without running it
    /// </summary>
    class Closures {

        /// <summary>
        /// Version with a single method
        /// </summary>
        /// 

        //1
        //static MyWrapperClass Counter() {
        //    int counter = 0;

        //    List<Action> my_List = new List<Action>();
        //    Func<int> inc = () => ++counter;
        //    Func<int> dec = () => --counter;
        //    Action<int> assign = (value) => counter = value;
        //    return new MyWrapperClass(inc, dec, assign);
        //}

        //2
        static Tuple<Func<int>, Func<int>, Action<int>> Counter()
        {
            int counter = 0;

            List<Action> my_List = new List<Action>();
            Func<int> inc = () => ++counter;
            Func<int> dec = () => --counter;
            Action<int> assign = (value) => counter = value;
            return new Tuple<Func<int>, Func<int>, Action<int>>(inc, dec, assign);
        }

        //3
        static void Counter(out Func<int> inc, out Func<int> dec, out Action<int> assign)
        {
            int counter = 0;
            inc = () => ++counter;
            dec = () => --counter;
            assign = (value) => counter = value;
        }

        static void Main() {
            //Func<int> counter = Counter();
            //Console.WriteLine(counter());
            //Console.WriteLine(counter());

            //Func<int> anotherCounter = Counter();
            //Console.WriteLine(anotherCounter());
            //Console.WriteLine(anotherCounter());

            //Console.WriteLine(counter());
            //Console.WriteLine(counter());

            Func<int> inc;
            Func<int> dec;
            Action<int> assign;

            Counter(out inc, out dec, out assign);
            Console.WriteLine(inc()); //1
            Console.WriteLine(inc()); //2
            Console.WriteLine(dec()); //1
            Console.WriteLine(dec()); //0
            assign(8);
            Console.WriteLine(inc()); //9
            Console.WriteLine(inc()); //10


        }
    }

}
