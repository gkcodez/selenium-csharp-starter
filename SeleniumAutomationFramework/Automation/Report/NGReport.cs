using System;
using Automation.Base;
using Automation.Enums;
using Automation.Helpers;

namespace Automation.Report
{
	public class NGReport
	{
		static NGReport()
		{
			Initialize();
		}

		private static void Initialize()
		{
			if (Config.ReportEnabled)
			{
				PerformanceHelper.StartBuild();
				DBHelper.ConnectDB();
				DBHelper.ExecuteStoredProcedure("dbo.InsertBuild", $"ExecutedBy | {Environment.MachineName.ToUpper()}", $"ExecutionDate | {DateTime.Now.ToString("ddd, MMMM d, yyyy").ToUpper()}", $"ExecutionTime | { DateTime.Now.ToString("T").ToUpper()}");
			}
		}

		public static void CreateTest(string testName)
		{
			if (Config.ReportEnabled)
			{
				PerformanceHelper.StartTestCase();
				DBHelper.ExecuteStoredProcedure("dbo.InsertTestCase", $"TestCaseName | {testName.ToUpper()}");
			}
		}

		public static void WriteLine(string description, Result result, string screenshotPath = null, Exception exception = null)
		{
			if (Config.ReportEnabled)
			{
				if (exception == null)
				{
					DBHelper.ExecuteStoredProcedure("dbo.InsertTestStep", $"AppName | {Config.AppName.ToUpper()}", $"Description | {description.ToUpper()}", $"Result | {result.ToString().Trim().ToUpper()}");
				}
				else
				{
					DBHelper.ExecuteStoredProcedure("dbo.InsertTestStep", $"AppName | {Config.AppName.ToUpper()}", $"Description | {description.ToUpper()}", $"Result | {result.ToString().Trim().ToUpper()}", $"Screenshot | {ScreenshotHelper.Screenshot}", $"Exception | {exception.Message.Trim().ToUpper()}");
				}
			}
		}

		public static void FinishTest()
		{
			PerformanceHelper.FinishTestCase();
			DBHelper.ExecuteStoredProcedure("dbo.UpdateTestCaseDuration", $"Duration |{ PerformanceHelper.TestCaseDuration}");
		}

		public static void Flush()
		{
			if (Config.ReportEnabled)
			{
				DBHelper.ExecuteStoredProcedure("dbo.UpdateTestCaseResult");
				DBHelper.ExecuteStoredProcedure("dbo.UpdateBuildResult");
				DBHelper.ExecuteStoredProcedure("dbo.UpdateBuildSummary");
				PerformanceHelper.FinishBuild();
				DBHelper.ExecuteStoredProcedure("dbo.UpdateBuildDuration", $"Duration|{PerformanceHelper.BuildDuration}");
			}
		}
	}
}