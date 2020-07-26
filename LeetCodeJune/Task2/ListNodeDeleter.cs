namespace LeetCodeJune.Task2
{
    public static class ListNodeDeleter
    {
        public static void DeleteNode(ListNode node)
        {
            var temp = node.next;
            node.val = temp.val;
            node.next = temp.next;
        }
    }
}