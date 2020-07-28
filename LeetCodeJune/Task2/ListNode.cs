namespace LeetCodeJune.Task2
{
    public class ListNode
    {
        public ListNode(int x)
        {
            val = x;
        }

        public override string ToString()
        {
            return $"{val}->{next}";
        }

        public ListNode next;
        public int val;
    }
}