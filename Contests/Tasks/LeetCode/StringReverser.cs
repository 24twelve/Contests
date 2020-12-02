using FluentAssertions;
using NUnit.Framework;

namespace Contests.Tasks.LeetCode
{
    public static class StringReverser
    {
        public static void ReverseString(char[] s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                var oppositeCharPointer = s.Length - 1 - i;
                var oppositeChar = s[oppositeCharPointer];
                s[oppositeCharPointer] = s[i];
                s[i] = oppositeChar;
            }
        }
    }

    public class ReverseStringTests
    {
        [TestCase("hello", "olleh")]
        [TestCase("hel1oo", "oo1leh")]
        [TestCase("", "")]
        [TestCase("a", "a")]
        public void TestReverse(string input, string expected)
        {
            var str1 = input.ToCharArray();
            StringReverser.ReverseString(str1);
            string.Join("", str1).Should().BeEquivalentTo(expected);
        }
    }
}