using System.Text.RegularExpressions;

namespace Automation.Helpers
{
	public static class RegexHelper
	{
		public static string ExecuteRegex(this string input, string pattern)
		{
			MatchCollection matchcollection = Regex.Matches(input, pattern);
			string result = string.Empty;
			foreach (Match match in matchcollection)
			{
				result += match.ToString(); ;
			}
			return result;
		}
	}
}