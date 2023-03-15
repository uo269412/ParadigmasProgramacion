using System;
using linked.list;

namespace use.linked.list
{
    class Program
    {
        static void Main()
        {
            List l = new List();
            l.Add(1);
            Console.WriteLine(l.NumberOfElements); //1
            l.Add(2);
            Console.WriteLine(l.NumberOfElements); //2
            l.Add(3);
            Console.WriteLine(l.NumberOfElements); //3
            Console.WriteLine(l.GetElement(0)); //1
            Console.WriteLine(l.GetElement(1)); //2
            Console.WriteLine(l.GetElement(2)); //3
            l.Remove(1);
            Console.WriteLine(l.GetElement(0)); //2
            Console.WriteLine(l.NumberOfElements); //2
            l.Remove(2);
            Console.WriteLine(l.GetElement(0)); //3
            Console.WriteLine(l.NumberOfElements); //1
            l.Remove(0);
        }
    }
}