using System;
using System.Collections.Generic;

namespace LeetCodeJune.Task6
{
    public static class QueueReconstructor
    {
        public static int[][] ReconstructQueue(int[][] people)
        {
            var result = new int[people.Length][];
            Array.Sort(people, new ArrayComparer());

            var list = new List<int[]>();
            foreach (var item in people) list.Insert(item[1], item);

            return list.ToArray();
        }

        private class ArrayComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] != y[0])
                    return y[0] - x[0];
                return x[1] - y[1];
            }
        }
    }
}