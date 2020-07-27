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

        //todo: several digit numbers and other next nodes
        //todo: make it several class
        [NotNull]
        public string Print(bool printNextNodes = false)
        {
            var copy = TreeNodeHelpers.Copy(this);
            TreeNodeHelpers.PopulateWithFakeNodes(copy, -1);

            if (copy.IsLeaf())
                return val.ToString();

            return string.Join("\r\n", PrintRecursively(copy, printNextNodes));
        }


        private static string[] PrintRecursively(TreeNode node, bool printNextNodes)
        {
            if (node.IsTriplet())
                return PrintTriplet(node, printNextNodes);
            return ConnectToRoot(node.val, PrintRecursively(node.left, printNextNodes),
                PrintRecursively(node.right, printNextNodes));
        }

        private static string[] PrintTriplet(TreeNode node, bool printNextNodes)
        {
            return new[]
            {
                $"  {PrintNode(node, printNextNodes)}  ",
                $"{PrintNode(node.left, printNextNodes)}   {PrintNode(node.right, printNextNodes)}"
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
        private static string PrintNode([CanBeNull] TreeNode node, bool printNextNodes)
        {
            if (node == null || node.val == -1) return " ";
            var result = $"{node.val}";
            if (printNextNodes)
                result = $"{node.val}->{node.next?.val}";
            return result;
        }

        [NotNull]
        private static string ReplaceChar([NotNull] string str, [NotNull] string character, int index)
        {
            str = str.Remove(index, 1);
            return str.Insert(index, character);
        }
    }
}