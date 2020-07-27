using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.FindPoisonedDuration
{
    public class FindPoisonedDurationTests
    {
        [Test]
        public void TestNoAttacks()
        {
            FindPoisonedDuration.Find(new int[0], 0).Should().Be(0);
            FindPoisonedDuration.Find(new int[0], 1).Should().Be(0);
            FindPoisonedDuration.Find(new int[0], 2).Should().Be(0);
        }

        [Test]
        public void TestAttacksWithNoPoison()
        {
            FindPoisonedDuration.Find(new[] {1}, 0).Should().Be(0);
            FindPoisonedDuration.Find(new[] {1, 2}, 0).Should().Be(0);
            FindPoisonedDuration.Find(new[] {1, 2, 5}, 0).Should().Be(0);
        }

        [Test]
        public void TestSingleAttack()
        {
            FindPoisonedDuration.Find(new[] {1}, 1).Should().Be(1);
            FindPoisonedDuration.Find(new[] {1}, 2).Should().Be(2);
            FindPoisonedDuration.Find(new[] {1}, 1000).Should().Be(1000);
        }

        [Test]
        public void TestTwoAttacks_NoOverlap()
        {
            FindPoisonedDuration.Find(new[] {2, 4}, 2).Should().Be(4);
            FindPoisonedDuration.Find(new[] {2, 10}, 2).Should().Be(4);
        }

        [Test]
        public void TestTwoAttacksOverlap_RenewPoison()
        {
            FindPoisonedDuration.Find(new[] {1, 2}, 2).Should().Be(3);
            FindPoisonedDuration.Find(new[] {1, 2}, 10).Should().Be(11);
        }

        [Test]
        public void TestManyAttacksWithinLongPoisonDuration()
        {
            FindPoisonedDuration.Find(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 100).Should().Be(109);
        }
    }
}