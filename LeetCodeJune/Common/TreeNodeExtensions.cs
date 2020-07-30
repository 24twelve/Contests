using System;

namespace LeetCodeJune.Common
{
    public static class TreeNodeExtensions
    {
        public static string Print(this TreeNode? node, bool printNextNodes = false)
        {
            return new TreeNodePrinter(printNextNodes).Print(node);
        }

        public static bool IsTriplet(this TreeNode node)
        {
            if (node.left == null || node.right == null)
                return false;
            return node.left.IsLeaf() && node.right.IsLeaf();
        }

        public static bool IsLeaf(this TreeNode node)
        {
            return node.left == null && node.right == null;
        }

        public static TreeNode PopulateWithFakeNodes(this TreeNode root)
        {
            var height = CalculateHeight(root);
            PopulateWithFakeNodes(root, height);
            return root;
        }

        public static TreeNode Copy(this TreeNode root)
        {
            var result = new TreeNode(root.val);
            result.next = root.next;
            if (root.left != null)
                result.left = Copy(root.left);
            if (root.right != null)
                result.right = Copy(root.right);
            return result;
        }

        public static int CalculateHeight(this TreeNode root)
        {
            var height = 0;
            CalculateHeight(root, 0, ref height);
            return height;
        }


        private static void PopulateWithFakeNodes(this TreeNode root, int currentHeight)
        {
            if (currentHeight <= 1)
                return;
            root.left ??= new TreeNode(-1) {IsFake = true};
            root.right ??= new TreeNode(-1) {IsFake = true};
            PopulateWithFakeNodes(root.left, currentHeight - 1);
            PopulateWithFakeNodes(root.right, currentHeight - 1);
        }

        private static void CalculateHeight(this TreeNode node, int currentFloor, ref int maxFloor)
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