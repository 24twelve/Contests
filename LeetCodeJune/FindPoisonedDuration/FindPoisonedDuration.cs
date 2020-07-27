namespace LeetCodeJune.FindPoisonedDuration
{
    public static class FindPoisonedDuration
    {
        public static int Find(int[] timeSeries, int duration)
        {
            var result = 0;
            for (var i = 0; i < timeSeries.Length; i++)
            {
                if (i + 1 == timeSeries.Length)
                {
                    result += duration;
                    continue;
                }

                var distance = timeSeries[i + 1] - timeSeries[i];
                if (distance > duration)
                    result += duration;
                else
                    result += distance;
            }

            return result;
        }
    }
}