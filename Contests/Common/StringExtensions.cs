namespace Contests.Common
{
    public static class StringExtensions
    {
        public static string ReplacePosition(this string str, char newChar, int position)
        {
            return str.Substring(0, position) + newChar + str.Substring(position + 1);
        }
    }
}