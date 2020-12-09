using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Contests.Tasks.LeetCode
{
    public static class TwoCityScheduler
    {
        public static int TwoCitySchedCost(int[][] costs)
        {
            var result = 0;
            var orderedCosts = costs.OrderBy(x => x[0] - x[1]).ToArray();
            for (var i = 0; i < costs.Length; i++)
            {
                if (i < costs.Length / 2)
                {
                    result += orderedCosts[i][0];
                }
                else
                {
                    result += orderedCosts[i][1];
                }
            }

            return result;
        }
    }

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
                new[] {30, 20}
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
                new[] {30, 20}
            };

            TwoCityScheduler.TwoCitySchedCost(costs).Should().Be(170);
        }
    }
}