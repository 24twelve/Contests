using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeJune.Common.Tests
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
            singleNode.CalculateHeight().Should().Be(1);

            var twoNodesRight = new TreeNode(1, right: new TreeNode(2));
            twoNodesRight.CalculateHeight().Should().Be(2);

            var twoNodesLeft = new TreeNode(1, new TreeNode(2));
            twoNodesLeft.CalculateHeight().Should().Be(2);

            var triplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            triplet.CalculateHeight().Should().Be(2);

            var level4Tree = new TreeNode();
            level4Tree.left = new TreeNode(111, new TreeNode(666), new TreeNode(222));
            level4Tree.right = new TreeNode(333, new TreeNode(444), new TreeNode(555, new TreeNode(7)));

            level4Tree.CalculateHeight().Should().Be(4);
        }

        [Test]
        public void TestCopy()
        {
            var triplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var copyTriplet = triplet.Copy();
            copyTriplet.Should().BeEquivalentTo(triplet);
            copyTriplet.Should().NotBeSameAs(triplet);

            var tripletWithNextNodes = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            tripletWithNextNodes.left.next = tripletWithNextNodes.right;
            var copyTripletWithNextNodes = tripletWithNextNodes.Copy();
            copyTripletWithNextNodes.Should().BeEquivalentTo(tripletWithNextNodes);
            copyTripletWithNextNodes.Should().NotBeSameAs(tripletWithNextNodes);


            var singleNode = new TreeNode(1);
            var copySingleNode = singleNode.Copy();
            copySingleNode.Should().NotBeSameAs(singleNode);
            copySingleNode.Should().BeEquivalentTo(singleNode);
        }

        [Test]
        public void TestPopulateWithFakeNodes()
        {
            var oneNodeRight = new TreeNode(1, right: new TreeNode(3));
            var oneNodeRightPopulated = new TreeNode(1, new TreeNode(-1) {IsFake = true}, new TreeNode(3));
            oneNodeRight.PopulateWithFakeNodes();
            oneNodeRight.Should().BeEquivalentTo(oneNodeRightPopulated);

            var oneNodeLeft = new TreeNode(1, new TreeNode(3));
            var oneNodeLeftPopulated = new TreeNode(1, new TreeNode(3), new TreeNode(-1) {IsFake = true});
            oneNodeLeft.PopulateWithFakeNodes();
            oneNodeLeft.Should().BeEquivalentTo(oneNodeLeftPopulated);

            var triplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var notPopulatedTriplet = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            triplet.PopulateWithFakeNodes();
            triplet.Should().BeEquivalentTo(notPopulatedTriplet);

            var level3Tree = new TreeNode(1, right: new TreeNode(2, right: new TreeNode(3)));
            var level3TreePopulated = new TreeNode(1);
            level3TreePopulated.right = new TreeNode(2, new TreeNode(-1) {IsFake = true}, new TreeNode(3));
            level3TreePopulated.left =
                new TreeNode(-1, new TreeNode(-1) {IsFake = true}, new TreeNode(-1) {IsFake = true}) {IsFake = true};
            level3Tree.PopulateWithFakeNodes();
            level3Tree.Should().BeEquivalentTo(level3TreePopulated);

            var singleNode = new TreeNode(1);
            singleNode.PopulateWithFakeNodes();
            singleNode.Should().BeEquivalentTo(singleNode);
        }
    }
}