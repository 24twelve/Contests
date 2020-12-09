namespace Contests.Common
{
    public static class ArrayExtensions
    {
        public static T? GetValueOrNull<T>(this T[] array, int index) where T : class
        {
            if (index < 0 || index >= array.Length)
            {
                return null;
            }

            return array[index];
        }
    }
}