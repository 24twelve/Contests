﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeetCodeJune
{
    public static class Helpers
    {
        public static string ToPrettyJson<T>(this T obj, Formatting formatting = Formatting.None)
        {
            return JsonConvert.SerializeObject(obj, formatting, new StringEnumConverter());
        }
    }
}