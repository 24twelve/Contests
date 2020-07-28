using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LeetCodeJune.Common
{
    public class TreeNodePrinter
    {
        public TreeNodePrinter(bool shouldPrintNextNodes = false)
        {
            this.shouldPrintNextNodes = shouldPrintNextNodes;
        }

        //todo: several digit numbers and other next nodes
        [NotNull]
        public string Print(TreeNode node)
        {
            var copy = node.Copy();
            copy.PopulateWithFakeNodes(-1);

            if (copy.IsLeaf())
                return PrintNode(node);

            return string.Join("\r\n", PrintRecursively(copy));
        }


        private string[] PrintRecursively(TreeNode node)
        {
            if (node.IsTriplet())
                return PrintTriplet(node);
            return ConnectToRoot(node, PrintRecursively(node.left),
                PrintRecursively(node.right));
        }

        private string[] PrintTriplet(TreeNode node)
        {
            return new[]
            {
                $"  {PrintNode(node)}  ",
                $"{PrintNode(node.left)}   {PrintNode(node.right)}"
            };
        }

        [NotNull]
        [ItemNotNull]
        private string[] ConnectToRoot(TreeNode root, [NotNull] [ItemNotNull] string[] leftArr,
            [NotNull] [ItemNotNull] string[] rightArr)
        {
            if (leftArr.Length != rightArr.Length)
                throw new ArgumentException("Arguments should have equal length");
            var result = new List<string>();
            for (var i = 0; i < leftArr.Length; i++)
                result.Add($"{leftArr[i]} {rightArr[i]}");

            var baseLength = result[0].Length;
            var baseStr = string.Join("", Enumerable.Repeat(" ", baseLength));
            result.Insert(0, ReplaceChar(baseStr, PrintNode(root), baseLength / 2));
            return result.ToArray();
        }


        [NotNull]
        private string PrintNode([CanBeNull] TreeNode node)
        {
            if (node == null || node.val == -1)
                return " ";
            var result = $"{node.val}";
            if (shouldPrintNextNodes)
                result = $"{node.val}->{node.next?.val}";
            return result;
        }

        [NotNull]
        private string ReplaceChar([NotNull] string str, [NotNull] string character, int index)
        {
            str = str.Remove(index, 1);
            return str.Insert(index, character);
        }

        private readonly bool shouldPrintNextNodes;
    }
}