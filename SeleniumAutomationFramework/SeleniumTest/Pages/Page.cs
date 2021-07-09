using Automation.Base;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest.Pages
{
	public class Page
	{
		private static T GetPage<T>() where T : new()
		{
			var page = new T();
			PageFactory.InitElements(Driver.Instance, page);
			return page;
		}

		public static HomePage Home
		{
			get
			{
				return GetPage<HomePage>();
			}
		}

		public static LoginPage Login
		{
			get
			{
				return GetPage<LoginPage>();
			}
		}

		public static FlightFinderPage FindFlights
		{
			get
			{
				return GetPage<FlightFinderPage>();
			}
		}

		public static SelectFlightPage SelectFlight
		{
			get
			{
				return GetPage<SelectFlightPage>();
			}
		}

		public static BookFlightPage BookFlight
		{
			get
			{
				return GetPage<BookFlightPage>();
			}
		}
	}
}