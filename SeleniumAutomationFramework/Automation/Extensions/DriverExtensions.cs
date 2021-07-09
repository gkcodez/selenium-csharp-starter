using System;
using System.Runtime.InteropServices;
using Automation.Enums;
using Automation.Helpers;
using Automation.Report;
using OpenQA.Selenium;

namespace Automation.Extensions
{
	public static class DriverExtensions
	{
		public static void GoToUrl(this IWebDriver driver, string url, [Optional]string expectedTitle)
		{
			driver.Navigate().GoToUrl(url);
			if (!string.IsNullOrEmpty(expectedTitle))
			{
				if (driver.Title.Contains(expectedTitle))
				{
					NGReport.WriteLine($"Actual Title {driver.Title} Contains Expected Title {expectedTitle}", Result.Passed);
				}
				else
				{
					NGReport.WriteLine($"Actual Title {driver.Title} Does Not Contain Expected Title {expectedTitle}", Result.Failed, ScreenshotHelper.Screenshot, new Exception($"Actual Title {driver.Title} Does Not Contain Expected Title {expectedTitle}"));
				}
			}
		}

		public static void Maximize(this IWebDriver driver)
		{
			driver.Manage().Window.Maximize();
		}
	}
}