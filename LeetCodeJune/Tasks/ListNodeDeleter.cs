using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Tasks
{
    public static class ListNodeDeleter
    {
        public static void DeleteNode(ListNode node)
        {
            var temp = node.next;
            node.val = temp.val;
            node.next = temp.next;
        }
    }

    public class DeleteNodeTests
    {
        [Test]
        public void TestExampleList()
        {
            var nodeToDelete = new ListNode(5) {next = new ListNode(1) {next = new ListNode(9)}};
            var inputHead = new ListNode(4) {next = nodeToDelete};
            var expected = new ListNode(4) {next = new ListNode(1) {next = new ListNode(9)}};

            Assert(nodeToDelete, inputHead, expected);
        }


        private static void Assert(ListNode nodeToDelete, ListNode inputHead, ListNode expected)
        {
            ListNodeDeleter.DeleteNode(nodeToDelete);

            Console.WriteLine($"Input: \r\n{inputHead}");
            Console.WriteLine($"Expected: \r\n{expected}");
            Console.WriteLine($"Actual: \r\n{inputHead}");
            inputHead.Should().BeEquivalentTo(expected);
        }
    }

    public class ListNode
    {
        public ListNode(int x)
        {
            val = x;
        }

        public override string ToString()
        {
            return $"{val}->{next}";
        }

        public ListNode next;
        public int val;
    }
}