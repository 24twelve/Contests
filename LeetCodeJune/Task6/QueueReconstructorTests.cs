using FluentAssertions;
using LeetCodeJune.Common;
using NUnit.Framework;

namespace LeetCodeJune.Task6
{
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