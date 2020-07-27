﻿using System;
using FluentAssertions;
using LeetCodeJune.Common;
using NUnit.Framework;

namespace LeetCodeJune.FindBottomLeftTreeValue
{
    public class FindBottomLeftTreeValueTests
    {
        [Test]
        public void TestNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => FindBottomLeftTreeValue.Find(null));
        }

        [Test]
        public void TestSingleNode()
        {
            var root = new TreeNode(6);
            FindBottomLeftTreeValue.Find(root).Should().Be(6);
        }

        [Test]
        public void TestSingleRightNode()
        {
            var root = new TreeNode(6, right: new TreeNode(9));
            FindBottomLeftTreeValue.Find(root).Should().Be(9);
        }

        [Test]
        public void TestSingleLeftNode()
        {
            var root = new TreeNode(6, new TreeNode(9));
            FindBottomLeftTreeValue.Find(root).Should().Be(9);
        }

        [Test]
        public void TestRightAndLeftNode_ChooseLeft()
        {
            var root = new TreeNode(6, new TreeNode(9), new TreeNode(1));
            Console.WriteLine(root.Print());
            FindBottomLeftTreeValue.Find(root).Should().Be(9);
        }

        [Test]
        public void TestSingleLeftLeftLeaf()
        {
            var root = new TreeNode(0, new TreeNode(9, new TreeNode(7)));
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestSingleLeftRightLeaf()
        {
            var root = new TreeNode(0, new TreeNode(9, right: new TreeNode(7)));
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestSingleRightLeftLeaf()
        {
            var root = new TreeNode(0, right: new TreeNode(9, new TreeNode(7)));
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestSingleRightRightLeaf()
        {
            var root = new TreeNode(0, right: new TreeNode(9, right: new TreeNode(7)));
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestTwoLeftLeaves_ChooseLeftLeft()
        {
            var root = new TreeNode(0, new TreeNode(9, new TreeNode(7), new TreeNode(666)));
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestAllLevel3Leaves_ChooseLeftLeft()
        {
            var root = new TreeNode();
            root.left = new TreeNode(111, new TreeNode(7), new TreeNode(222));
            root.right = new TreeNode(333, new TreeNode(444), new TreeNode(555));
            Console.WriteLine(root.Print());
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestLevel4Leaf()
        {
            var root = new TreeNode();
            root.left = new TreeNode(111, new TreeNode(666), new TreeNode(222));
            root.right = new TreeNode(333, new TreeNode(444), new TreeNode(555, new TreeNode(7)));
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestTwoLevel4Leaves()
        {
            var root = new TreeNode();
            root.left = new TreeNode(111, new TreeNode(666), new TreeNode(222));
            root.right = new TreeNode(333, new TreeNode(444), new TreeNode(555, new TreeNode(7), new TreeNode(999)));
            Console.WriteLine(root.Print());
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestTwoLevel4Leaves_DifferentBranches()
        {
            var root = new TreeNode();
            root.left = new TreeNode(111, new TreeNode(666), new TreeNode(222, right: new TreeNode(7)));
            root.right = new TreeNode(333, new TreeNode(444), new TreeNode(555, new TreeNode(999)));
            Console.WriteLine(root.Print());
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }

        [Test]
        public void TestTwoLevel4AndLevel5Leaves()
        {
            var root = new TreeNode();
            root.left = new TreeNode(111, new TreeNode(666), new TreeNode(222, right: new TreeNode(888)));
            root.right = new TreeNode(333, new TreeNode(444),
                new TreeNode(555, new TreeNode(999, right: new TreeNode(7))));
            Console.WriteLine(root.Print());
            FindBottomLeftTreeValue.Find(root).Should().Be(7);
        }
    }
}