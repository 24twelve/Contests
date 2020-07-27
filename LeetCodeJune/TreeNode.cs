using System.Collections.Generic;

namespace LeetCodeJune
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

        //todo: do good
        public override string ToString()
        {
            var result = new List<string>
            {
                $"      {val}      ",
                $"    {left?.val}  {right?.val}",
                $"  {left?.left?.val}  {left?.right?.val}  {right?.left?.val}  {right?.right?.val}",
                $"{left?.left?.left?.val}  {left?.left?.right?.val}  {left?.right?.left?.val}  {left?.right?.right?.val}  {right?.left?.left?.val}  {right?.left?.right?.val}  {right?.right?.left?.val}  {right?.right?.right?.val}"
            };

            return string.Join("\r\n", result);
        }
    }
}