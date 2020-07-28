using System;
using JetBrains.Annotations;

namespace LeetCodeJune.Common
{
    public static class TreeNodeExtensions
    {
        [NotNull]
        public static TreeNode PopulateWithFakeNodes([NotNull] this TreeNode root, int fakeNodeValue)
        {
            var height = CalculateHeight(root);
            PopulateWithFakeNodes(root, fakeNodeValue, height);
            return root;
        }

        [NotNull]
        public static TreeNode Copy([NotNull] this TreeNode root)
        {
            var result = new TreeNode(root.val);
            result.next = root.next;
            if (root.left != null)
                result.left = Copy(root.left);
            if (root.right != null)
                result.right = Copy(root.right);
            return result;
        }

        public static int CalculateHeight([NotNull] this TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException();

            var height = 0;
            CalculateHeight(root, 0, ref height);
            return height;
        }


        private static void PopulateWithFakeNodes(this TreeNode root, int fakeNodeValue, int currentHeight)
        {
            if (currentHeight <= 1) return;
            if (root.left == null)
                root.left = new TreeNode(fakeNodeValue);
            if (root.right == null)
                root.right = new TreeNode(fakeNodeValue);
            PopulateWithFakeNodes(root.left, fakeNodeValue, currentHeight - 1);
            PopulateWithFakeNodes(root.right, fakeNodeValue, currentHeight - 1);
        }

        private static void CalculateHeight([NotNull] this TreeNode node, int currentFloor, ref int maxFloor)
        {
            currentFloor++;
            maxFloor = Math.Max(currentFloor, maxFloor);
            if (node.left != null)
                CalculateHeight(node.left, currentFloor, ref maxFloor);
            if (node.right != null)
                CalculateHeight(node.right, currentFloor, ref maxFloor);
        }
    }
}