using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    internal static class Tools
    {
        internal static T[][] CreateArray<T>(int n, int m)
        {
            var array = new T[n][];

            for (int i = 0; i < n; i++)
            {
                array[i] = new T[m];
            }

            return array;
        }

        public static T[][] ArrayCast<T>(List<List<T>> list)
        {
            return list.Select(el => el.ToArray()).ToArray();
        }

        public static T[][] ArrayCast<T>(IEnumerable<IEnumerable<T>> list)
        {
            return list.Select(el => el.ToArray()).ToArray();
        }
    }
}
