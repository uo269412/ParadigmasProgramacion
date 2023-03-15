using System;
using linked.list;

namespace use.linked.list
{
    class Program
    {
        static void Main()
        {
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            foreach(var element in l)
            {
                Console.WriteLine(element);
            }
        }
    }
}