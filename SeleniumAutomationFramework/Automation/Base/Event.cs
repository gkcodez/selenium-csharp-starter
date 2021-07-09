using System;
using Automation.Enums;
using Automation.Extensions;
using Automation.Helpers;
using Automation.Log;
using Automation.Report;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace Automation.Base
{
	public static class Event
	{
		private static By by = null;
		private static IWebDriver driver = null;

		public static void OnNavigating(object sender, WebDriverNavigationEventArgs e)
		{
			Wait.WaitForPageLoad();
			NGReport.WriteLine($"Navigating to : {e.Url}", Result.Passed);
			NGLog.Info($"Navigating to : {e.Url}");
		}

		public static void OnFindingElement(object sender, FindElementEventArgs e)
		{
			try
			{
				by = e.FindMethod;
				driver = e.Driver;
				Wait.WaitUntilElementVisible(driver, by);
				NGReport.WriteLine($"Finding Element : {e.FindMethod}", Result.Passed);
				NGLog.Info($"Finding Element : {e.FindMethod}");
			}
			catch (Exception ex)
			{
				NGReport.WriteLine($"Could Not Find Element {e.FindMethod}", Result.Failed, ScreenshotHelper.Screenshot, ex);
			}
		}

		public static void OnClickingElement(object sender, WebElementEventArgs e)
		{
			try
			{
				Wait.WaitUntilElementClickable(driver, by);
				NGReport.WriteLine($"Clicking Element : {e.ToStringElement()}", Result.Passed);
				NGLog.Info($"Clicking Element : {e.ToStringElement()}");
			}
			catch (Exception ex)
			{
				NGReport.WriteLine($"Clicking Element : {e.ToStringElement()}", Result.Passed, ScreenshotHelper.Screenshot, ex);
			}
		}

		public static void OnValueChanged(object sender, WebElementEventArgs e)
		{
			NGReport.WriteLine($"Value Changed: {e.Element.GetAttribute("value")} On Element : {e.ToStringElement()}", Result.Passed);
			NGLog.Info($"Value Changed: {e.Element.GetAttribute("value")} On Element : {e.ToStringElement()}");
		}

		private static string ToStringElement(this WebElementEventArgs e)
		{
			return string.Format(
				"{0}{1}{2}{3}{4}{5}{6}{7}",
				e.Element.TagName.ToPascal(),
				AppendAttribute(e, "id"),
				AppendAttribute(e, "name"),
				AppendAttribute(e, "class"),
				AppendAttribute(e, "type"),
				AppendAttribute(e, "role"),
				AppendAttribute(e, "text"),
				AppendAttribute(e, "href"));
		}

		private static string AppendAttribute(WebElementEventArgs e, string attribute)
		{
			var attrValue = attribute == "text" ? e.Element.Text : e.Element.GetAttribute(attribute);
			return string.IsNullOrEmpty(attrValue) ? string.Empty : string.Format(" | By.{0}:{1}", attribute.ToPascal(), attrValue);
		}
	}
}