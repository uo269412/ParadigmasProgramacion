using System.Linq;
using System.Collections.Generic;
using System;

namespace TPP.Laboratory.Functional.Lab07 {

    static public class Functions {

        public static IEnumerable<TResult> Map<TElement, TResult>(this IEnumerable<TElement> collection, Func<TElement, TResult> function) {
            foreach(TElement element in collection)
            {
                yield return function(element);      
            }
            yield break;
        }
        public static T Find<T> (this IEnumerable<T> collection, Predicate<T> function)
        {
            T result = default;
            foreach (var element in collection)
            {
                if (function(element))
                {
                    result = element;
                    break;
                }
            }
            return result;
        }

        public static IEnumerable<T> Filter<T> (this IEnumerable<T> collection, Predicate<T> function)
        {
            foreach(T element in collection)
            {
                if (function(element))
                {
                    yield return element;
                }
            }
        }
        public static TResult Reduce<TElement, TResult>(this IEnumerable<TElement> collection, TResult init, Func<TElement, TResult, TResult> function)
        {
            var result = init;
            foreach (var element in collection)
            {
                result = function(element, result);
            }
            return result;
        }
    }
}
