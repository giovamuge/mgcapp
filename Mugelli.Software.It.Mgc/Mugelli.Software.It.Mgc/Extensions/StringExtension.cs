using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mugelli.Software.It.Mgc.Extensions
{
    public static class StringExtension
    {
        public static List<string> ToParseList(this string source, char[] value = null)
        {
            if (source == null) return new List<string>();
            if (value == null) value = new[] {','};
            return source.Split(value).ToList();
        }

        public static string ToParseSingleEscape(this string source)
        {
            //TODO: Scegliere se ritornare empty o null
            if (string.IsNullOrEmpty(source)) return string.Empty;
            //if (string.IsNullOrEmpty(source)) return null;
            while (source.IndexOf(@"\", StringComparison.Ordinal) > -1)
                source = Regex.Unescape(source);

            return source;
        }

        public static string ToParseDoubleEscape(this string source)
        {
            return Regex.Escape(source ?? string.Empty);
        }

        public static string ToDecodeEmoji(this string source)
        {
            return ParseUnicodeHex(BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(source ?? string.Empty))
                .Replace("-", ""));
        }

        public static string EncodeNonAsciiCharacters(this string value)
        {
            //TODO: Scegliere se ritornare empty o null
            if (string.IsNullOrEmpty(value)) return string.Empty;
            //if (string.IsNullOrEmpty(value)) return null;
            var sb = new StringBuilder();
            foreach (var c in value)
                if (c > 127)
                {
                    // This character is too big for ASCII
                    var encodedValue = "\\u" + ((int) c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            return sb.ToString();
        }

        public static string DecodeEncodedNonAsciiCharacters(this string value)
        {
            return Regex.Replace(value, @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m => ((char) int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
        }

        private static string ParseUnicodeHex(string hex)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < hex.Length; i += 4)
            {
                var temp = hex.Substring(i, 4);
                sb.Append($@"\u{temp}");
            }
            return sb.ToString();
        }

        public static string ToCamelCase(this string value)
        {
            return new string(CharsToTitleCase(value).ToArray());
        }

        private static IEnumerable<char> CharsToTitleCase(string s)
        {
            var newWord = true;
            foreach (var c in s)
            {
                if (newWord)
                {
                    yield return char.ToUpper(c);
                    newWord = false;
                }
                else
                {
                    yield return char.ToLower(c);
                }
                if (c == ' ') newWord = true;
            }
        }

        public static T ToEnum<T>(this string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }

        public static Uri ToUri(this string value, UriKind kind = UriKind.Absolute)
        {
            return !string.IsNullOrEmpty(value) ? new Uri(value, kind) : null;
        }

        public static Uri ToUri(this object value, UriKind kind = UriKind.Absolute)
        {
            return !string.IsNullOrEmpty(Convert.ToString(value)) ? new Uri(Convert.ToString(value), kind) : null;
        }

        public static string Truncate(this string value, int maxLength, bool pointerAfter = false)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength
                ? value
                : pointerAfter
                    ? $"{value.Substring(0, maxLength)}.."
                    : value.Substring(0, maxLength);
        }
    }
}