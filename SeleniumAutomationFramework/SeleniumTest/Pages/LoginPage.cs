using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest.Pages
{
	public class LoginPage
	{
		[CacheLookup]
		[FindsBy(How = How.Name, Using = "userName")]
		private IWebElement UserName { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "password")]
		private IWebElement Password { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "login")]
		private IWebElement SignInButton { get; set; }

		public void LogintoNewTours(string username, string password)
		{
			UserName.SendKeys(username);
			Password.SendKeys(password);
			SignInButton.Click();
		}
	}
}