using System;
using Automation.Enums;
using Automation.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace Automation.Base
{
	public static class Driver
	{
		private static IWebDriver instance;
		private static WebDriverWait browserWait;
		private static readonly object threadlock = new object();

		public static IWebDriver Instance
		{
			get
			{
				lock (threadlock)
				{
					if (instance == null)
					{
						Browser browser = Config.TestBrowser;
						string driverPath = Config.DriverPath;

						switch (browser)
						{
							case Browser.Firefox:
								instance = new FirefoxDriver();
								break;

							case Browser.Chrome:
								instance = new ChromeDriver(driverPath);
								break;

							case Browser.InternetExplorer:
								instance = new InternetExplorerDriver(driverPath);
								break;

							case Browser.Safari:
								instance = new SafariDriver(driverPath);
								break;

							case Browser.Headless:
								break;

							default:
								break;
						}

						EventFiringWebDriver eventDriver = new EventFiringWebDriver(Instance);
						eventDriver.Navigating += Event.OnNavigating;
						eventDriver.FindingElement += Event.OnFindingElement;
						eventDriver.ElementClicking += Event.OnClickingElement;
						eventDriver.ElementValueChanged += Event.OnValueChanged;
						instance = eventDriver;
						browserWait = new WebDriverWait(instance, TimeSpan.FromSeconds(Config.TimeoutMedium));
						browserWait.PollingInterval = TimeSpan.FromMilliseconds(100);
						instance.Maximize();
					}
				}
				return instance;
			}
		}

		public static void Flush()
		{
			Instance.Quit();
			instance = null;
		}
	}
}