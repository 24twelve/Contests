namespace Contests.Common
{
    public class TreeNode
    {
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }


        public override string ToString()
        {
            return val.ToString();
        }

        public bool IsFake;
        public TreeNode? left;
        public TreeNode? next;
        public TreeNode? right;
        public int val;
    }
}