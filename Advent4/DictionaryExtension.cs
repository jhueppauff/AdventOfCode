using System;
using System.Collections.Generic;
using System.Text;

namespace Advent4
{
    public static class DictionaryExtension
    {
        public static Dictionary<TKey, TElement> ToSafeDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentException("source");
            if (keySelector == null)
                throw new ArgumentException("keySelector");
            if (elementSelector == null)
                throw new ArgumentException("elementSelector");
            Dictionary<TKey, TElement> d = new Dictionary<TKey, TElement>(comparer);
            foreach (TSource element in source)
            {
                if (!d.ContainsKey(keySelector(element)))
                    d.Add(keySelector(element), elementSelector(element));
            }
            return d;
        }
    }
}
