using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Task8
{
    public class PowerOfTwoTests
    {
        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        [TestCase(15, false)]
        [TestCase(1073741824, true)]
        [TestCase(1073741825, false)]
        public void Test(int n, bool expected)
        {
            PowerOfTwo.IsPowerOfTwo(n).Should().Be(expected, $"{n}");
        }
    }
}