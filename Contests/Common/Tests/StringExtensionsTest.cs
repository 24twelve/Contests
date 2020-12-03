using FluentAssertions;
using NUnit.Framework;

namespace Contests.Common.Tests
{
    public class StringExtensionsTest
    {
        [TestCase("abc", 'x', 0, "xbc")]
        [TestCase("abc", 'x', 1, "axc")]
        [TestCase("abc", 'x', 2, "abx")]
        public void TestReplacePosition(string initial, char newChar, int position, string expected)
        {
            initial.ReplacePosition(newChar, position).Should().BeEquivalentTo(expected);
        }
    }
}