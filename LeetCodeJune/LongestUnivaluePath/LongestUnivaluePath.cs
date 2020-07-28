using System;
using System.Collections.Generic;
using System.Linq;
using LeetCodeJune.Common;

namespace LeetCodeJune.LongestUnivaluePath
{
    public static class LongestUnivaluePath
    {
        public static int Find(TreeNode root)
        {
            if (root == null)
                return 0;

            var paths = new List<int>();
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Any())
            {
                var node = stack.Pop();
                paths.Add(FindLongestJointPath(node));
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }

            return paths.Max();
        }

        public static int FindLongestJointPath(TreeNode root)
        {
            var rightPath = 0;
            var leftPath = 0;
            if (root.right != null && root.right.val == root.val)
            {
                var someInt = 0;
                FindLongestPathDown(root.right, ref rightPath, ref someInt);
                rightPath++;
            }

            if (root.left != null && root.left.val == root.val)
            {
                var someInt = 0;
                FindLongestPathDown(root.left, ref leftPath, ref someInt);
                leftPath++;
            }

            return rightPath + leftPath;
        }

        public static void FindLongestPathDown(TreeNode node, ref int currentLongestPath, ref int currentPath)
        {
            currentLongestPath = Math.Max(currentPath, currentLongestPath);
            if (node.right != null && node.right.val == node.val)
            {
                var newCurrentPath = currentPath;
                newCurrentPath++;
                FindLongestPathDown(node.right, ref currentLongestPath, ref newCurrentPath);
            }

            ;

            if (node.left != null && node.left.val == node.val)
            {
                var newCurrentPath = currentPath;
                newCurrentPath++;
                FindLongestPathDown(node.left, ref currentLongestPath, ref newCurrentPath);
            }
        }
    }
}