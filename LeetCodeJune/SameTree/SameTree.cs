using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.SameTree
{
    public static class IsSameTree
    {
        public static bool IsSame(TreeNode first, TreeNode second)
        {
            if (first == second) 
                return true;
            if (first == null)
                return false;
            if (second == null)
                return false;

            if (first.val != second.val)
                return false;

            if (IsSame(first.right, second.right))
                if (IsSame(first.left, second.left))
                    return true;
            return false;
        }
    }

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
            var node1 = new TreeNode(1,left: new TreeNode(2), right: new TreeNode(3));
            var node2 = new TreeNode(1,left: new TreeNode(2), right: new TreeNode(3));
            var node3 = new TreeNode(1,left: new TreeNode(999), right: new TreeNode(3));
            var node4 = new TreeNode(1,left: new TreeNode(2), right: new TreeNode(999));
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
            IsSameTree.IsSame(node1, node4).Should().BeFalse();
        }

        [Test]
        public void TestOnlyRight()
        {
            var node1 = new TreeNode(1,right: new TreeNode(3, right: new TreeNode(4)));
            var node2 = new TreeNode(1,right: new TreeNode(3, right: new TreeNode(4)));
            var node3 = new TreeNode(1,right: new TreeNode(999, right: new TreeNode(4)));
            var node4 = new TreeNode(1,right: new TreeNode(3, right: new TreeNode(999)));
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
            IsSameTree.IsSame(node1, node4).Should().BeFalse();

        } 
        
        [Test]
        public void TestOnlyLeft()
        {
            var node1 = new TreeNode(1,left: new TreeNode(3, left: new TreeNode(4)));
            var node2 = new TreeNode(1,left: new TreeNode(3, left: new TreeNode(4)));
            var node3 = new TreeNode(1,left: new TreeNode(999, left: new TreeNode(4)));
            var node4 = new TreeNode(1,left: new TreeNode(3, left: new TreeNode(999)));
            IsSameTree.IsSame(node1, node2).Should().BeTrue();
            IsSameTree.IsSame(node1, node3).Should().BeFalse();
            IsSameTree.IsSame(node1, node4).Should().BeFalse();
        }

        [Test]
        public void TestStructuralInequal()
        {
            var node1 = new TreeNode(1,left: new TreeNode(3, left: new TreeNode(4)));
            var node2 = new TreeNode(1, right: new TreeNode(3, right: new TreeNode(4)));
            IsSameTree.IsSame(node1, node2).Should().BeFalse();
        }

    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}