using System;
using FluentAssertions;
using LeetCodeJune.Common;
using NUnit.Framework;

namespace LeetCodeJune.LongestUnivaluePath
{
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
            var root = new TreeNode(1, new TreeNode(1), new TreeNode(1));
            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestTwoPaths_TwoLevels()
        {
            var root = new TreeNode(1, new TreeNode(1), new TreeNode(1));
            root.left.left = new TreeNode(1);
            root.right.right = new TreeNode(1);
            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(4);
        }

        [Test]
        public void TestExample()
        {
            var root = new TreeNode(5) {left = new TreeNode(4), right = new TreeNode(5) {right = new TreeNode(5)}};
            root.left.right = new TreeNode(1);
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestExample2()
        {
            var root = new TreeNode(1) {left = new TreeNode(4), right = new TreeNode(5) {right = new TreeNode(5)}};
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(4);

            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestExample3()
        {
            var root = new TreeNode(2) {left = new TreeNode(2), right = new TreeNode(2) {right = new TreeNode(2)}};
            root.left.right = new TreeNode(2);
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(4);
        }

        [Test]
        public void TestExample4()
        {
            var root = new TreeNode(2)
                {left = new TreeNode(2), right = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2)}}};
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(4);
        }

        [Test]
        public void TestExample5()
        {
            var root = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2)}}};
            root.left = new TreeNode(1);

            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(3);
        }

        [Test]
        public void TestTwoPathsForOneValue()
        {
            var root = new TreeNode(1) {right = new TreeNode(2) {right = new TreeNode(2) {right = new TreeNode(2)}}};
            root.left = new TreeNode(2) {left = new TreeNode(2)};

            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestNoDuplicates()
        {
            var root = new TreeNode(6) {left = new TreeNode(4), right = new TreeNode(7) {right = new TreeNode(8)}};
            root.left.right = new TreeNode(5);
            root.left.left = new TreeNode(1);

            Console.WriteLine(root.Print());
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
            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestOnlyRight_WithoutRoot()
        {
            var root = new TreeNode(5) {right = new TreeNode(6) {right = new TreeNode(6)}};
            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(1);
        }

        [Test]
        public void TestOnlyLeft()
        {
            var root = new TreeNode(6) {left = new TreeNode(6) {left = new TreeNode(6)}};
            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(2);
        }

        [Test]
        public void TestOnlyLeft_WithoutRoot()
        {
            var root = new TreeNode(7) {left = new TreeNode(6) {left = new TreeNode(6)}};
            Console.WriteLine(root.Print());
            LongestUnivaluePath.Find(root).Should().Be(1);
        }


        [Test]
        public void TestOnlyLeft_WithoutLeaf()
        {
            var root = new TreeNode(6) {left = new TreeNode(6) {left = new TreeNode(5)}};
            Console.WriteLine(root.Print());
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
            Console.WriteLine(root.Print());

            LongestUnivaluePath.Find(root).Should().Be(4);
        }
    }
}