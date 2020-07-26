using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCodeJune.LongestUnivaluePath
{
    public static class LongestUnivaluePath
    {
        public static int Find(TreeNode root)
        {
            if (root == null) return 0;

            var paths = new List<int>();
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Any())
            {
                var node = stack.Pop();
                paths.Add(FindLongestJointPath(node));
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }

            return paths.Max();
        }

        public static int FindLongestJointPath(TreeNode root)
        {
            var rightPath = 0;
            var leftPath = 0;
            if (root.right != null && root.right.val == root.val)
            {
                var someInt = 0;
                FindLongestPathDown(root.right,ref rightPath,ref someInt);
                rightPath++;
            }

            if (root.left != null && root.left.val == root.val)
            {
                var someInt = 0;
                FindLongestPathDown(root.left, ref leftPath, ref someInt);
                leftPath++;
            }

            return rightPath + leftPath;
        }

        public static void FindLongestPathDown(TreeNode node, ref int currentLongestPath, ref int currentPath)
        {
            currentLongestPath = Math.Max(currentPath, currentLongestPath);
            if (node.right != null && node.right.val == node.val)
            {
                var newCurrentPath = currentPath;
                newCurrentPath++;
                FindLongestPathDown(node.right, ref currentLongestPath, ref newCurrentPath);
            };

            if (node.left != null && node.left.val == node.val)
            {
                var newCurrentPath = currentPath;
                newCurrentPath++;
                FindLongestPathDown(node.left, ref currentLongestPath, ref newCurrentPath);
            }

        }
    }

    public class LongestUnivaluePathTests
    {
        [Test]
        public void TestNull()
        {
            LongestUnivaluePath.Find(null).Should().Be(0);
        }

        [Test]
        public void TestTwoPaths()
        {
            var root = new TreeNode(1, left: new TreeNode(1), right: new TreeNode(1));
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestTwoPaths_TwoLevels()
        {
            var root = new TreeNode(1, left: new TreeNode(1), right: new TreeNode(1));
            root.left.left = new TreeNode(1);
            root.right.right = new TreeNode(1);
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(4);
        }

        [Test]
        public void TestExample()
        {
            var root = new TreeNode(5) {left = new TreeNode(4), right = new TreeNode(5) {right = new TreeNode(5)}};
            root.left.right = new TreeNode(1);
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestExample2()
        {
            var root = new TreeNode(1) {left = new TreeNode(4), right = new TreeNode(5) {right = new TreeNode(5)}};
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(4);

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestExample3()
        {
            var root = new TreeNode(2) {left = new TreeNode(2), right = new TreeNode(2) {right = new TreeNode(2)}};
            root.left.right = new TreeNode(2);
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(4);
        }

        [Test]
        public void TestExample4()
        {
            var root = new TreeNode(2)
                {left = new TreeNode(2), right = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2)}}};
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(4);
        }

        [Test]
        public void TestExample5()
        {
            var root = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2)}}};
            root.left = new TreeNode(1);

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(3);
        }

        [Test]
        public void TestTwoPathsForOneValue()
        {
            var root = new TreeNode(1) {right = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2)}}};
            root.left = new TreeNode(2) {left = new TreeNode(2)};

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestNoDuplicates()
        {
            var root = new TreeNode(6) {left = new TreeNode(4), right = new TreeNode(7) {right = new TreeNode(8)}};
            root.left.right = new TreeNode(5);
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(0);
        }

        [Test]
        public void TestSingleNode()
        {
            LongestUnivaluePath.Find(new TreeNode(6)).Should().Be(0);
        }

        [Test]
        public void TestOnlyRight()
        {
            var root = new TreeNode(6) {right = new TreeNode(6) {right = new TreeNode(6)}};
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestOnlyRight_WithoutRoot()
        {
            var root = new TreeNode(5) {right = new TreeNode(6) {right = new TreeNode(6)}};
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(1);
        }

        [Test]
        public void TestOnlyLeft()
        {
            var root = new TreeNode(6) {left = new TreeNode(6) {left = new TreeNode(6)}};
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestOnlyLeft_WithoutRoot()
        {
            var root = new TreeNode(7) {left = new TreeNode(6) {left = new TreeNode(6)}};
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(1);
        }


        [Test]
        public void TestOnlyLeft_WithoutLeaf()
        {
            var root = new TreeNode(6) {left = new TreeNode(6) {left = new TreeNode(5)}};
            Console.WriteLine(root.ToString());
            LongestUnivaluePath.Find(root).Should().Be(1);
        }

        [Test]
        public void TestConnectedNodesButNotInPath()
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(1);
            root.right.right = new TreeNode(1);
            root.right.right.left = new TreeNode(1);
            root.right.left = new TreeNode(1);
            root.right.left.left = new TreeNode(1);
            root.right.left.right = new TreeNode(1);
            Console.WriteLine(root.ToString());

            LongestUnivaluePath.Find(root).Should().Be(4);
        }
    }


    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        //todo: do good
        public override string ToString()
        {
            var result = new List<string>
            {
                $"      {val}      ",
                $"    {left?.val}  {right?.val}",
                $"  {left?.left?.val}  {left?.right?.val}  {right?.left?.val}  {right?.right?.val}",
                $"{left?.left?.left?.val}  {left?.left?.right?.val}  {left?.right?.left?.val}  {left?.right?.right?.val}  {right?.left?.left?.val}  {right?.left?.right?.val}  {right?.right?.left?.val}  {right?.right?.right?.val}"
            };

            return string.Join("\r\n", result);
        }
    }
}