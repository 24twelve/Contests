namespace LeetCodeJune.Task1
{
    public static class BinaryTreeInvertor
    {
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            InvertTree(root.right);
            InvertTree(root.left);
            var temp = root.right;
            root.right = root.left;
            root.left = temp;
            return root;
        }
    }
}