using Automation.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest.Pages
{
	public class BookFlightPage
	{
		[CacheLookup]
		[FindsBy(How = How.Name, Using = "passFirst0")]
		private IWebElement PassengerFirstName { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "passLast0")]
		private IWebElement PassengerLastName { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "pass.0.meal")]
		private IWebElement MealPreference { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "creditCard")]
		private IWebElement CardType { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "creditnumber")]
		private IWebElement CardNumber { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "buyFlights")]
		private IWebElement BuyTickets { get; set; }

		public void BookTickets()
		{
			PassengerFirstName.SendKeys("GopalakrishnanPV");
			PassengerLastName.SendKeys("Panchavarnam");
			MealPreference.SelectDropdownWithValue("VGML");
			CardType.SelectDropdownWithValue("BA");
			CardNumber.SendKeys("0123456789");
			BuyTickets.Click();
		}
	}
}