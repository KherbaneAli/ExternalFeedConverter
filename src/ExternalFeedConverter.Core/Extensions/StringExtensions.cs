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

        public static double ToDouble(this string str)
        {
            return double.TryParse(str, out var output)
                ? output
                : 0;
        }
    }
}