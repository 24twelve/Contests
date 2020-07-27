using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeetCodeJune.Common
{
    public static class SerializeHelpers
    {
        public static string ToPrettyJson<T>(this T obj, Formatting formatting = Formatting.None)
        {
            return JsonConvert.SerializeObject(obj, formatting, new StringEnumConverter());
        }
    }
}