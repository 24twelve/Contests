using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Common
{
    public class TreeNodeHelpersTests
    {
        [Test]
        public void TestCalculateHeight_Null_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => TreeNodeExtensions.CalculateHeight(null));
        }

        [Test]
        public void TestCalculateHeight()
        {
            var singleNode = new TreeNode(1);
            TreeNodeExtensions.CalculateHeight(singleNode).Should().Be(1);

            var twoNodesRight = new TreeNode(1, right: new TreeNode(2));
            TreeNodeExtensions.CalculateHeight(twoNodesRight).Should().Be(2);

            var twoNodesLeft = new TreeNode(1, new TreeNode(2));
            TreeNodeExtensions.CalculateHeight(twoNodesLeft).Should().Be(2);

            var triplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            TreeNodeExtensions.CalculateHeight(triplet).Should().Be(2);

            var level4Tree = new TreeNode();
            level4Tree.left = new TreeNode(111, new TreeNode(666), new TreeNode(222));
            level4Tree.right = new TreeNode(333, new TreeNode(444), new TreeNode(555, new TreeNode(7)));

            TreeNodeExtensions.CalculateHeight(level4Tree).Should().Be(4);
        }

        [Test]
        public void TestCopy()
        {
            var triplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var copyTriplet = TreeNodeExtensions.Copy(triplet);
            copyTriplet.Should().BeEquivalentTo(triplet);
            copyTriplet.Should().NotBeSameAs(triplet);

            var tripletWithNextNodes = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            tripletWithNextNodes.left.next = tripletWithNextNodes.right;
            var copyTripletWithNextNodes = TreeNodeExtensions.Copy(tripletWithNextNodes);
            copyTripletWithNextNodes.Should().BeEquivalentTo(tripletWithNextNodes);
            copyTripletWithNextNodes.Should().NotBeSameAs(tripletWithNextNodes);


            var singleNode = new TreeNode(1);
            var copySingleNode = TreeNodeExtensions.Copy(singleNode);
            copySingleNode.Should().NotBeSameAs(singleNode);
            copySingleNode.Should().BeEquivalentTo(singleNode);
        }

        [Test]
        public void TestPopulateWithFakeNodes()
        {
            var oneNodeRight = new TreeNode(1, right: new TreeNode(3));
            var oneNodeRightPopulated = new TreeNode(1, new TreeNode(-1), new TreeNode(3));
            TreeNodeExtensions.PopulateWithFakeNodes(oneNodeRight, -1);
            oneNodeRight.Should().BeEquivalentTo(oneNodeRightPopulated);

            var oneNodeLeft = new TreeNode(1, new TreeNode(3));
            var oneNodeLeftPopulated = new TreeNode(1, new TreeNode(3), new TreeNode(-1));
            TreeNodeExtensions.PopulateWithFakeNodes(oneNodeLeft, -1);
            oneNodeLeft.Should().BeEquivalentTo(oneNodeLeftPopulated);

            var triplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var notPopulatedTriplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            TreeNodeExtensions.PopulateWithFakeNodes(triplet, -1);
            triplet.Should().BeEquivalentTo(notPopulatedTriplet);

            var level3Tree = new TreeNode(1, right: new TreeNode(2, right: new TreeNode(3)));
            var level3TreePopulated = new TreeNode(1);
            level3TreePopulated.right = new TreeNode(2, new TreeNode(-1), new TreeNode(3));
            level3TreePopulated.left = new TreeNode(-1, new TreeNode(-1), new TreeNode(-1));
            TreeNodeExtensions.PopulateWithFakeNodes(level3Tree, -1);
            level3Tree.Should().BeEquivalentTo(level3TreePopulated);

            var singleNode = new TreeNode(1);
            TreeNodeExtensions.PopulateWithFakeNodes(singleNode, -1);
            singleNode.Should().BeEquivalentTo(singleNode);
        }
    }
}