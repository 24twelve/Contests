using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Task3
{
    public class TwoCitySchedulerTests
    {
        //1 <= costs.length <= 100
        //It is guaranteed that costs.length is even.
        //1 <= costs[i][0], costs[i][1] <= 1000

        [Test]
        public void TestOriginalTask()
        {
            var costs = new[]
            {
                new[] {10, 20},
                new[] {30, 200},
                new[] {400, 50},
                new[] {30, 20},
            };
            TwoCityScheduler.TwoCitySchedCost(costs).Should().Be(110);
        }

        [Test]
        public void NotNaiveCase()
        {
            var costs = new[]
            {
                new[] {10, 20},
                new[] {10, 20},
                new[] {10, 20},
                new[] {30, 200},

                new[] {10, 20},
                new[] {10, 20},
                new[] {400, 50},
                new[] {30, 20},
            };

            TwoCityScheduler.TwoCitySchedCost(costs).Should().Be(170);
        }
    }
}
