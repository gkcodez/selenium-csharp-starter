using System.Collections.Generic;
using System.Threading;
using Automation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Extensions
{
	public static class WebElementExtensions
	{
		public static void Highlight(this IWebElement element)
		{
			IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.Instance);
			js.ExecuteScript("arguments[0].style.border='2px solid red'", element);
			Thread.Sleep(500);
			js.ExecuteScript("arguments[0].style.border=''", element);
		}

		public static IWebElement WaitForElement(this IWebElement radioButtons)
		{
			return null;
		}

		public static IWebElement SelectedRadioButton(this IList<IWebElement> radioButtons)
		{
			foreach (var radioButton in radioButtons)
			{
				if (radioButton.Selected)
				{
					return radioButton;
				}
			}
			return null;
		}

		public static void ClickRadioButtonWithText(this IList<IWebElement> radioButtons, string radioButtonText)
		{
			foreach (var radioButton in radioButtons)
			{
				if (radioButton.Text.Trim().Equals(radioButtonText))
				{
					radioButton.Click();
				}
			}
		}

		public static void ClickRadioButtonWithValue(this IList<IWebElement> radioButtons, string radioButtonValue)
		{
			foreach (var radioButton in radioButtons)
			{
				if (radioButton.GetAttribute("value").Trim().Equals(radioButtonValue))
				{
					radioButton.Click();
				}
			}
		}

		public static void SelectDropdownWithText(this IWebElement dropDown, string dropDownText)
		{
			SelectElement select = new SelectElement(dropDown);
			select.SelectByText(dropDownText);
		}

		public static void SelectDropdownWithValue(this IWebElement dropDown, string dropDownValue)
		{
			SelectElement select = new SelectElement(dropDown);
			select.SelectByValue(dropDownValue);
		}
	}
}