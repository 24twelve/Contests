namespace LeetCodeJune.Task4
{
    public static class StringReverser
    {
        public static void ReverseString(char[] s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                var oppositeCharPointer = s.Length - 1 - i;
                var oppositeChar = s[oppositeCharPointer];
                s[oppositeCharPointer] = s[i];
                s[i] = oppositeChar;
            }
        }
    }
}