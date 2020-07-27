using LeetCodeJune.Common;

namespace LeetCodeJune.SameTree
{
    public static class IsSameTree
    {
        public static bool IsSame(TreeNode first, TreeNode second)
        {
            if (first == second)
                return true;
            if (first == null)
                return false;
            if (second == null)
                return false;

            if (first.val != second.val)
                return false;

            if (IsSame(first.right, second.right))
                if (IsSame(first.left, second.left))
                    return true;
            return false;
        }
    }
}