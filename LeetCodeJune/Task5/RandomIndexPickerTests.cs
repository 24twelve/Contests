using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace LeetCodeJune.Task5
{
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
            for (var _ = 0; _ < numberOfSamples; _++) result.Add(indexPicker.PickIndex());

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