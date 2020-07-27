using FluentAssertions;
using LeetCodeJune.Common;
using NUnit.Framework;

namespace LeetCodeJune.SameTree
{
    public class SameTreeTests
    {
        [Test]
        public void TestReferences()
        {
            var tree = new TreeNode(1);
            IsSameTree.IsSame(tree, tree).Should().BeTrue();
            IsSameTree.IsSame(null, null).Should().BeTrue();
            IsSameTree.IsSame(tree, null).Should().BeFalse();
            IsSameTree.IsSame(null, tree).Should().BeFalse();
        }

        [Test]
        public void TestSingleNode()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(1);
            var node3 = new TreeNode(2);
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
        }

        [Test]
        public void TestThreeNodes()
        {
            var node1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var node2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var node3 = new TreeNode(1, new TreeNode(999), new TreeNode(3));
            var node4 = new TreeNode(1, new TreeNode(2), new TreeNode(999));
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
            IsSameTree.IsSame(node1, node4).Should().BeFalse();
        }

        [Test]
        public void TestOnlyRight()
        {
            var node1 = new TreeNode(1, right: new TreeNode(3, right: new TreeNode(4)));
            var node2 = new TreeNode(1, right: new TreeNode(3, right: new TreeNode(4)));
            var node3 = new TreeNode(1, right: new TreeNode(999, right: new TreeNode(4)));
            var node4 = new TreeNode(1, right: new TreeNode(3, right: new TreeNode(999)));
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
            IsSameTree.IsSame(node1, node4).Should().BeFalse();
        }

        [Test]
        public void TestOnlyLeft()
        {
            var node1 = new TreeNode(1, new TreeNode(3, new TreeNode(4)));
            var node2 = new TreeNode(1, new TreeNode(3, new TreeNode(4)));
            var node3 = new TreeNode(1, new TreeNode(999, new TreeNode(4)));
            var node4 = new TreeNode(1, new TreeNode(3, new TreeNode(999)));
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
            IsSameTree.IsSame(node1, node4).Should().BeFalse();
        }

        [Test]
        public void TestStructuralInequal()
        {
            var node1 = new TreeNode(1, new TreeNode(3, new TreeNode(4)));
            var node2 = new TreeNode(1, right: new TreeNode(3, right: new TreeNode(4)));
            IsSameTree.IsSame(node1, node2).Should().BeFalse();
        }
    }
}