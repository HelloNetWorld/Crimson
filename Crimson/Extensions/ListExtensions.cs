using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Crimson.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            if (coll == null) throw new ArgumentNullException(nameof(coll));

            var c = new ObservableCollection<T>();
            foreach (var e in coll)
            {
                c.Add(e);
            } 

            return c;
        }
    }
}
