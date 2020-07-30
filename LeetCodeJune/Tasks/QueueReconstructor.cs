using System;
using System.Collections.Generic;
using FluentAssertions;
using LeetCodeJune.Common;
using NUnit.Framework;

namespace LeetCodeJune.Tasks
{
    public static class QueueReconstructor
    {
        public static int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, new ArrayComparer());

            var list = new List<int[]>();
            foreach (var item in people)
                list.Insert(item[1], item);

            return list.ToArray();
        }

        private class ArrayComparer : IComparer<int[]>
        {
            public int Compare(int[]? x, int[]? y)
            {
                if (x == null)
                {
                    if (y == null)
                        return 1;
                    return -1;
                }

                if (y == null)
                    return -1;

                if (x[0] != y[0])
                    return y[0] - x[0];
                return x[1] - y[1];
            }
        }
    }

    public class QueueReconstructorTests
    {
        [Test]
        public void TestExample()
        {
            var input = new[]
            {
                new[] {7, 0},
                new[] {4, 4},
                new[] {7, 1},
                new[] {5, 0},
                new[] {6, 1},
                new[] {5, 2}
            };
            var expected = new[]
            {
                new[] {5, 0},
                new[] {7, 0},
                new[] {5, 2},
                new[] {6, 1},
                new[] {4, 4},
                new[] {7, 1}
            };
            var actual = QueueReconstructor.ReconstructQueue(input);
            actual.ToPrettyJson().Should().BeEquivalentTo(expected.ToPrettyJson());
        }
    }
}