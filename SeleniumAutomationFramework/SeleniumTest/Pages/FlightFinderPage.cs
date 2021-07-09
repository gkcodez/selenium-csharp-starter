using System.Collections.Generic;
using Automation.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest.Pages
{
	public class FlightFinderPage
	{
		[CacheLookup]
		[FindsBy(How = How.Name, Using = "tripType")]
		private IList<IWebElement> TripType { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "passCount")]
		private IWebElement PassengerCount { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "fromPort")]
		private IWebElement FromPort { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "fromMonth")]
		private IWebElement FromMonth { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "fromDay")]
		private IWebElement FromDay { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "toPort")]
		private IWebElement ToPort { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "toMonth")]
		private IWebElement ToMonth { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "toDay")]
		private IWebElement ToDay { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "servClass")]
		private IList<IWebElement> ServiceClass { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "airline")]
		private IWebElement Airline { get; set; }

		[CacheLookup]
		[FindsBy(How = How.Name, Using = "findFlights")]
		private IWebElement FindFlightsButton { get; set; }

		public void FindFlights()
		{
			TripType.ClickRadioButtonWithValue("oneway");
			PassengerCount.SelectDropdownWithValue("1");
			FromPort.SelectDropdownWithValue("Portland");
			FromMonth.SelectDropdownWithValue("8");
			FromDay.SelectDropdownWithValue("16");
			ToPort.SelectDropdownWithValue("Paris");
			ToMonth.SelectDropdownWithValue("9");
			ToDay.SelectDropdownWithValue("16");
			ServiceClass.ClickRadioButtonWithValue("Business");
			Airline.SelectDropdownWithText("Unified Airlines");
			FindFlightsButton.Click();
		}
	}
}