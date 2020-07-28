using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Common
{
    public class PrintTreeNodeTests
    {
        [Test]
        public void TestPrintSingleNode()
        {
            var root = new TreeNode(2);
            var expected = @"2";
            root.Print().Should().Be(expected);
        }

        [Test]
        public void TestPrintTriplet()
        {
            var root = new TreeNode(2, new TreeNode(4), new TreeNode(4));
            var expected = @"
  2  
4   4";
            Assert(root, expected);
        }

        [Test]
        public void TestPrintTripletWithMissingNodes()
        {
            var root1 = new TreeNode(2, right: new TreeNode(4));
            var expected1 = @"
  2  
    4";
            Assert(root1, expected1);

            var root2 = new TreeNode(2, new TreeNode(4));
            var expected2 = @"
  2  
4    ";
            Assert(root2, expected2);
        }

        [Test]
        public void TestPrintTwoTriplets()
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(3, new TreeNode(6), new TreeNode(7));
            root.left = new TreeNode(2, new TreeNode(4), new TreeNode(4));

            var expected = @"
     1     
  2     3  
4   4 6   7";

            Assert(root, expected);
        }

        [Test]
        public void TestPrintNextNodes()
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(3, new TreeNode(6), new TreeNode(7));
            root.left = new TreeNode(2, new TreeNode(4), new TreeNode(4));
            root.left.next = root.right;
            root.left.left.next = root.left.right;
            root.left.right.next = root.right.left;
            root.right.left.next = root.right.right;

            var expected = @"
        1->       
  2->3     3->  
4->4   4->6 6->7   7->";

            AssertPrintNextNodes(root, expected);
        }

        [Test]
        public void PrintBigTreeWithHoles()
        {
            var expected = @"
           1           
     2           3     
  4     4           7  
7   9     0       8   9";

            var root = new TreeNode(1);
            root.right = new TreeNode(3);
            root.right.right = new TreeNode(7, new TreeNode(8), new TreeNode(9));
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(4, right: new TreeNode());
            root.left.left = new TreeNode(4, new TreeNode(7), new TreeNode(9));

            Assert(root, expected);
        }


        private void Assert(TreeNode root, string expected)
        {
            var result = $"\r\n{root.Print()}";
            Console.WriteLine($"Result:\r\n{result}");
            result.Should().Be(expected);
        }

        private void AssertPrintNextNodes(TreeNode root, string expected)
        {
            var result = $"\r\n{root.Print(true)}";
            Console.WriteLine($"Result:\r\n{result}");
            result.Should().Be(expected);
        }
    }
}