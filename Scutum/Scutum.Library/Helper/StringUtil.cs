using System;
using System.Text;

namespace Scutum.Library.Helper
{
    public static class StringUtil
    {
        public static string ToBase64String(this string value)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(value));
        }

        public static string FromBase64String(this string value)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(value));
        }

        public static string Left(this string value, int length)
        {
            return value.Substring(0, length);
        }
    }
}