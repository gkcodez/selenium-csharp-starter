using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Automation.Extensions
{
	public static class StringExtensions
	{
		public static string ToPascal(this string text)
		{
			TextInfo info = Thread.CurrentThread.CurrentCulture.TextInfo;
			text = info.ToTitleCase(text);
			string[] parts = text.Split(new char[] { },
				StringSplitOptions.RemoveEmptyEntries);
			string result = string.Join(string.Empty, parts);
			return result;
		}

		public static string ToCamel(this string text)
		{
			text = text.ToPascal();
			return text.Substring(0, 1).ToLower() +
				text.Substring(1);
		}

		public static string ToProper(this string text)
		{
			const string pattern = @"(?<=\w)(?=[A-Z])";
			string result = Regex.Replace(text, pattern,
				" ", RegexOptions.None);
			return result.Substring(0, 1).ToUpper() + result.Substring(1);
		}
	}
}