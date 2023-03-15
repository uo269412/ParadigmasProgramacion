using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            string a1 = "2";
            string a2 = "1";
            Swap(ref a1, ref a2);
            Console.WriteLine(a1);
            Console.WriteLine(a2);

            string b1 = "1";
            string b2 = "2";
            Console.WriteLine(GetMaximum(b1, b2));

            //

            string[] my_list = new string[10];
            foreach (var s in my_list)
                Console.WriteLine(s);

            //

            System.Collections.IEnumerator it = my_list.GetEnumerator();
            while (it.MoveNext())
            {
                object s = it.Current;
                Console.WriteLine(s);
            }

            

        }

        static void Swap<T>(ref T a, ref T b)
        {
            var aux = a;
            a = b;
            b = aux;
        }

        static IComparable<T> GetMaximum<T>(IComparable<T> a, IComparable<T> b) 
        {
            if (a.CompareTo((T) b) > 0) //May lead to an invalid cast
            {
                return a;
            }
            return b;
        }

        static T GetMaximum<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            return b;
        }
    }
}
