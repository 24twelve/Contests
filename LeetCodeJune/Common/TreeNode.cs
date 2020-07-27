using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LeetCodeJune.Common
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode next;
        public TreeNode right;
        public int val;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        //todo: several digit numbers :)
        [NotNull]
        public string Print()
        {
            var copy = TreeNodeHelpers.Copy(this);
            TreeNodeHelpers.PopulateWithFakeNodes(copy, -1);

            if (copy.IsLeaf())
                return val.ToString();

            return string.Join("\r\n", PrintRecursively(copy));
        }


        private static string[] PrintRecursively(TreeNode node)
        {
            if (node.IsTriplet())
                return PrintTriplet(node);
            return ConnectToRoot(node.val, PrintRecursively(node.left), PrintRecursively(node.right));
        }

        private static string[] PrintTriplet(TreeNode node)
        {
            return new[]
            {
                $"  {PrintNode(node)}  ",
                $"{PrintNode(node.left)}   {PrintNode(node.right)}"
            };
        }

        [NotNull]
        [ItemNotNull]
        private static string[] ConnectToRoot(int root, [NotNull] [ItemNotNull] string[] leftArr,
            [NotNull] [ItemNotNull] string[] rightArr)
        {
            if (leftArr.Length != rightArr.Length)
                throw new ArgumentException("Arguments should have equal length");
            var result = new List<string>();
            for (var i = 0; i < leftArr.Length; i++)
                result.Add($"{leftArr[i]} {rightArr[i]}");

            var baseLength = result[0].Length;
            var baseStr = string.Join("", Enumerable.Repeat(" ", baseLength));
            result.Insert(0, ReplaceChar(baseStr, root.ToString(), baseLength / 2));
            return result.ToArray();
        }

        private bool IsTriplet()
        {
            if (left == null || right == null)
                return false;
            return left.IsLeaf() && right.IsLeaf();
        }

        private bool IsLeaf()
        {
            return left == null && right == null;
        }

        [NotNull]
        private static string PrintNode([CanBeNull] TreeNode node)
        {
            return node == null || node.val == -1 ? " " : $"{node.val}";
        }

        [NotNull]
        private static string ReplaceChar([NotNull] string str, [NotNull] string character, int index)
        {
            str = str.Remove(index, 1);
            return str.Insert(index, character);
        }
    }
}