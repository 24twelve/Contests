using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeJune.Task5
{
    public class RandomIndexPicker
    {
        private readonly (int Index, double Weigh)[] normalizedWeighs;


        private readonly Random random;

        public RandomIndexPicker(int[] w)
        {
            random = new Random();
            var sum = w.Sum();

            var normalized = new List<(int Index, double Weigh)>();
            double total = 0;
            for (var i = 0; i < w.Length; i++)
            {
                var weigh = (double) w[i] / sum;
                normalized.Add((i, total + weigh));
                total += weigh;
            }

            normalizedWeighs = normalized.OrderBy(x => x.Weigh).ToArray();
        }

        public int PickIndex()
        {
            var randomValue = random.NextDouble();
            foreach (var (index, weigh) in normalizedWeighs)
                if (randomValue <= weigh)
                    return index;

            return normalizedWeighs.Last().Index;
        }
    }
}