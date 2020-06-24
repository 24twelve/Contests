using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Task4
{
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