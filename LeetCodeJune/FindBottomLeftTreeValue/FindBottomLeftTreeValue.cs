using System;
using LeetCodeJune.Common;

namespace LeetCodeJune.FindBottomLeftTreeValue
{
    public static class FindBottomLeftTreeValue
    {
        public static int Find(TreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            var currentMaxPathLength = 0;
            var currentFurthestLeaf = root.val;
            FindLongestPath(root, 0, ref currentMaxPathLength, ref currentFurthestLeaf);
            return currentFurthestLeaf;
        }

        private static void FindLongestPath(TreeNode root, int currentPathLength, ref int currentMaxPathLength,
            ref int currentFurthestLeaf)
        {
            currentPathLength += 1;
            if (currentPathLength > currentMaxPathLength)
            {
                currentMaxPathLength = currentPathLength;
                currentFurthestLeaf = root.val;
            }

            if (root.left != null)
                FindLongestPath(root.left, currentPathLength, ref currentMaxPathLength, ref currentFurthestLeaf);
            if (root.right != null)
                FindLongestPath(root.right, currentPathLength, ref currentMaxPathLength, ref currentFurthestLeaf);
        }
    }
}