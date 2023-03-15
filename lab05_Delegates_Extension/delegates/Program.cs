using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP.Laboratory.Functional.Lab05;

namespace delegates
{
    //public delegate Person Comparison(Person p1, Person p2);
    public delegate double MyFirstDelegate(double p1);
    public static class ExtensionMethods
    {
        public static IEnumerable<double> Map(this IEnumerable<double> list, MyFirstDelegate function)
        {
            double[] copy = new double[list.Count()];
            int i = 0;
            foreach (double d in list)
            {
                copy[i++] = function(d);
            }
            return copy;
        }

        public static void Show(this IEnumerable<double> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

        public static string DisplayContents<T>(this IEnumerable<T> list)
        {
            string result = "";
            foreach (var element in list)
            {
                result = string.Concat(result, element.ToString());
            }
            return result;
        }

        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> list, Func<T1, T2> function)
        {
            T2[] copy = new T2[list.Count()];
            int i = 0;
            foreach (var d in list)
            {
                copy[i++] = function(d);
            }
            return copy;
        }

        public static void Show<T>(this IEnumerable<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

        public static T Find<T> (this IEnumerable<T> collection, Predicate<T> function)
        {
            T result = default;
          foreach(var element in collection)
            {
                if (function(element))
                {
                    result = element;
                    break;
                }
            }
            return result;
        }



        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> function)
        {
            T[] copy = new T[collection.Count()];
            int i = 0;
            foreach (var element in collection)
            {
                if (function(element))
                {
                    copy[i++] = element;
                }
            }
            Array.Resize(ref copy, i);
            return copy;
        }

        public static T2 Reduce<T1, T2>(this IEnumerable<T1> collection, T2 init, Func<T1, T2, T2> function)
        {
            var result = init;
            foreach (var element in collection)
            {
                result = function(element, result);
            }
            return result;
        }
    }



    class Program
    {
        public static double FunctionDouble(double a)
        {
            return a;
        }

        public static double DoubleOfNumber(double a)
        {
            return a * 2;
        }

        public static string DoubleToString(double a)
        {
            return "1";
        }

        public static IEnumerable<double> Map(IEnumerable<double> list, MyFirstDelegate function)
        {
            double[] copy = new double[list.Count()];
            int i = 0;
            foreach (double d in list)
            {
                copy[i++] = function(d);
            }
            return copy;
        }

        static void Main(string[] args)
        {
            // 1 - declare a variable
            // 2 - assign a value -- 4 - point a piece of code to a delegate
            MyFirstDelegate myVariable = FunctionDouble;
            // 3 - invoke the delegate
            var result = myVariable(5.5);

            MyFirstDelegate DoubleFunction = DoubleOfNumber;
            Console.WriteLine(DoubleFunction(4.4));

            double[] auxArray = new double[] { 2.3, 4.2 };
            var result2 = Program.Map(auxArray, DoubleFunction);
            foreach(var element in result2)
            {
                Console.WriteLine(element);
            }
            var result3 = auxArray.Map(DoubleFunction);
            result3.Show();

            Func<double, string> DoubleToStringFunc = DoubleToString;
            var result4 = auxArray.Map<double, string>(DoubleToString);
            result4.Show<string>();

            Person[] people = Factory.CreatePeople();
            var filteredPeople = people.Filter(p => p.Surname.Contains("z"));
            foreach (var element in filteredPeople)
            {
                Console.WriteLine(element);
            }
        }
    }

    //Action (void -> void)
    //Action<T> (T -> void)
    //Predicate<T> (T -> bool)
}
