using System;

namespace ExternalFeedConverter.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToCapitalCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            return str.Length > 2
                ? $"{str.Substring(0, 1).ToUpper()}{str.Substring(1, str.Length - 1).ToLower()}"
                : $"{str.Substring(0, 1).ToUpper()}";
        }

        public static int ToInt(this string str)
        {
            return int.TryParse(str, out var output)
                ? output
                : 0;
        }
        
        public static double ToDouble(this string str)
        {
            return double.TryParse(str, out var output)
                ? output
                : 0;
        }
        
        public static bool ToBoolean(this string str)
        {
            return Boolean.TryParse(str, out var output) && output;
        }
        
    }
}