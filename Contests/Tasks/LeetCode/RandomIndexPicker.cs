using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Contests.Tasks.LeetCode
{
    public class RandomIndexPicker
    {
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

        private readonly (int Index, double Weigh)[] normalizedWeighs;


        private readonly Random random;
    }

    public class RandomIndexPickerTests
    {
        [Test]
        public void TestSimpleInput()
        {
            var input = new[] {1, 1, 3}; //1/5, 1/5, 3/5
            var indexPicker = new RandomIndexPicker(input);
            var result = new List<int>();
            var numberOfSamples = 10_00000;
            var deviation = (int) Math.Sqrt(numberOfSamples) * 2;
            for (var _ = 0; _ < numberOfSamples; _++)
                result.Add(indexPicker.PickIndex());

            var part = numberOfSamples / 5;
            using (var _ = new AssertionScope())
            {
                var zeroIndexCount = result.Count(x => x == 0);
                var firstIndexCount = result.Count(x => x == 1);
                var secondIndexCount = result.Count(x => x == 2);
                Console.WriteLine($"{zeroIndexCount};{firstIndexCount};{secondIndexCount}");
                zeroIndexCount.Should().BeInRange(part - deviation, part + deviation);
                firstIndexCount.Should().BeInRange(part - deviation, part + deviation);
                secondIndexCount.Should().BeInRange(part * 3 - deviation, part * 3 + deviation);
            }
        }
    }
}