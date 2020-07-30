using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LeetCodeJune.Common;
using NUnit.Framework;

namespace LeetCodeJune.Tasks
{
    public static class PopulateNextRightPointer2
    {
        public static TreeNode Populate(TreeNode root)
        {
            if (root == null)
                return null;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var buffer = new List<TreeNode>();
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                if (currentNode.left != null)
                    buffer.Add(currentNode.left);
                if (currentNode.right != null)
                    buffer.Add(currentNode.right);

                if (queue.Any())
                {
                    currentNode.next = queue.Peek();
                }
                else
                {
                    foreach (var bufferNode in buffer)
                        queue.Enqueue(bufferNode);
                    buffer.Clear();
                }
            }

            return root;
        }
    }

    public class PopulateNextRightPointer2Tests
    {
        [Test]
        public void TestRoot()
        {
            var root = new TreeNode(1);
            var expectedRoot = new TreeNode(1);
            root.Should().BeEquivalentTo(expectedRoot);
        }

        [Test]
        public void TestOnlyRight()
        {
            var root = new TreeNode(1, right: new TreeNode(2));
            var expectedRoot = root.Copy();
            expectedRoot.Should().BeEquivalentTo(root);
        }


        [Test]
        public void TestOnlyLeft()
        {
            var root = new TreeNode(1, new TreeNode(2));
            var expectedRoot = root.Copy();
            expectedRoot.Should().BeEquivalentTo(root);
        }

        [Test]
        public void TestTriplet()
        {
            var root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var expectedRoot = root.Copy();
            expectedRoot.left.next = expectedRoot.right;
            Assert(root, expectedRoot);
        }

        [Test]
        public void TestTripletsLevel3()
        {
            var root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            var expectedRoot = root.Copy();
            expectedRoot.left.next = expectedRoot.right;
            expectedRoot.left.left.next = expectedRoot.left.right;
            expectedRoot.left.right.next = expectedRoot.right.left;
            expectedRoot.right.left.next = expectedRoot.right.right;

            Assert(root, expectedRoot);
        }

        [Test]
        public void TestHangingLevel3()
        {
            var root = new TreeNode(1, left: new TreeNode(2), right: new TreeNode(3));
            root.left.left = new TreeNode(4);
            root.right.right = new TreeNode(7);
            var expectedRoot = root.Copy();
            expectedRoot.left.next = expectedRoot.right;
            expectedRoot.left.left.next = expectedRoot.right.right;

            Assert(root, expectedRoot);
        }


        private void Assert(TreeNode actual, TreeNode expected)
        {
            PopulateNextRightPointer2.Populate(actual);
            var printer = new TreeNodePrinter(shouldPrintNextNodes: true);
            Console.WriteLine($"Expected:\r\n {printer.Print(expected)}");
            Console.WriteLine($"Actual:\r\n {printer.Print(actual)}");
            actual.Should().BeEquivalentTo(expected);
        }
    }
}