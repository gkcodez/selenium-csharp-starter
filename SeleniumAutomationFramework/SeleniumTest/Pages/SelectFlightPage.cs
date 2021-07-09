using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest.Pages
{
	public class SelectFlightPage
	{
		[CacheLookup]
		[FindsBy(How = How.XPath, Using = "//tr[9]//td[@class='frame_action_xrows']/input")]
		private IWebElement DepartFlight { get; set; }

		[CacheLookup]
		[FindsBy(How = How.XPath, Using = "//tr[5]//td[@class='frame_action_xrows']/input")]
		private IWebElement ReturnFlight { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "reserveFlights")]
		private IWebElement Continue { get; set; }

		public void SelectFlights()
		{
			DepartFlight.Click();
			ReturnFlight.Click();
			Continue.Click();
		}
	}
}