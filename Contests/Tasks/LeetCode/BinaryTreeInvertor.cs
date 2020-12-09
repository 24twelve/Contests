using System;
using Contests.Common;
using FluentAssertions;
using NUnit.Framework;

namespace Contests.Tasks.LeetCode
{
    public static class BinaryTreeInvertor
    {
        public static TreeNode? InvertTree(TreeNode? root)
        {
            if (root == null)
            {
                return null;
            }

            InvertTree(root.right);
            InvertTree(root.left);
            var temp = root.right;
            root.right = root.left;
            root.left = temp;
            return root;
        }
    }

    public class InvertBinaryTreeTests
    {
        [Test]
        public void InvertExampleBinaryTree()
        {
            var inputRoot = new TreeNode(4)
            {
                left = new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                right = new TreeNode(7, new TreeNode(6), new TreeNode(9))
            };

            var expectedRoot = new TreeNode(4)
            {
                left = new TreeNode(7, new TreeNode(9), new TreeNode(6)),
                right = new TreeNode(2, new TreeNode(3), new TreeNode(1))
            };

            Assert(inputRoot, expectedRoot);
        }

        [Test]
        public void InvertLeftOnlyTree()
        {
            var leftOnlyRoot = new TreeNode(100);
            leftOnlyRoot.left = new TreeNode(95);
            leftOnlyRoot.left.left = new TreeNode(90);

            var rightOnlyRoot = new TreeNode(100);
            rightOnlyRoot.right = new TreeNode(95);
            rightOnlyRoot.right.right = new TreeNode(90);

            Assert(leftOnlyRoot, rightOnlyRoot);
        }

        [Test]
        public void InvertRightOnlyTree()
        {
            var leftOnlyRoot = new TreeNode(100);
            leftOnlyRoot.left = new TreeNode(95);
            leftOnlyRoot.left.left = new TreeNode(90);

            var rightOnlyRoot = new TreeNode(100);
            rightOnlyRoot.right = new TreeNode(95);
            rightOnlyRoot.right.right = new TreeNode(90);

            Assert(rightOnlyRoot, leftOnlyRoot);
        }

        [Test]
        public void InvertRoot()
        {
            var root = new TreeNode(4);
            Assert(root, root);
        }

        [Test]
        public void InvertNull()
        {
            Assert(null, null);
        }

        private static void Assert(TreeNode? inputRoot, TreeNode? expectedRoot)
        {
            var actual = BinaryTreeInvertor.InvertTree(inputRoot);
            Console.WriteLine($"Input: \r\n{inputRoot}");
            Console.WriteLine($"Expected: \r\n{expectedRoot}");
            Console.WriteLine($"Actual: \r\n{actual}");
            actual.Should().BeEquivalentTo(expectedRoot);
        }
    }
}