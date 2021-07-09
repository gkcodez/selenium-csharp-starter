using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Base
{
	public class Wait
	{
		public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
		{
			try
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
				return wait.Until(ExpectedConditions.ElementExists(elementLocator));
			}
			catch (NoSuchElementException)
			{
				throw new Exception("Element with locator: '" + elementLocator + "' was not found in current context page.");
			}
		}

		public static IWebElement WaitUntilElementVisible(IWebDriver driver, By elementLocator, int timeout = 10)
		{
			try
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
				return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
			}
			catch (NoSuchElementException)
			{
				throw new Exception("Element with locator: '" + elementLocator + "' was not found in current context page.");
			}
		}

		public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator, int timeout = 10)
		{
			try
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
				return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
			}
			catch (NoSuchElementException)
			{
				throw new Exception("Element with locator: '" + elementLocator + "' was not found in current context page.");
			}
		}

		public static void WaitForPageLoad()
		{
			Driver.Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.TimeoutMedium);
		}
	}
}