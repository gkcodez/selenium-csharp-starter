using System;

namespace Automation.Helpers
{
	public class PerformanceHelper
	{
		private static DateTime buildStartTime;
		private static DateTime buildEndTime;
		private static DateTime testCaseStartTime;
		private static DateTime testCaseEndTime;

		public static void StartBuild()
		{
			buildStartTime = DateTime.Now;
		}

		public static void FinishBuild()
		{
			buildEndTime = DateTime.Now;
		}

		public static string BuildDuration
		{
			get
			{
				TimeSpan duration = buildEndTime.Subtract(buildStartTime);
				string durationString = duration.ToString("hh\\:mm\\:ss\\:fff");
				return durationString;
			}
		}

		public static void StartTestCase()
		{
			testCaseStartTime = DateTime.Now;
		}

		public static void FinishTestCase()
		{
			testCaseEndTime = DateTime.Now;
		}

		public static string TestCaseDuration
		{
			get
			{
				TimeSpan duration = testCaseEndTime.Subtract(testCaseStartTime);
				string durationString = duration.ToString("hh\\:mm\\:ss\\:fff");
				return durationString;
			}
		}
	}
}