using System.Collections.Generic;

namespace LeetCodeJune.Task1
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            var result = new List<string>();
            result.Add($"    {val}    ");
            result.Add($"  {left?.val}    {right?.val}");
            result.Add($"{left?.left?.val}  {left?.right?.val}  {right?.left?.val}  {right?.right?.val}");

            return string.Join("\r\n", result);
        }
    }
}