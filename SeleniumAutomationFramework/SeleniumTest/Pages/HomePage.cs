using Automation.Base;
using Automation.Extensions;

namespace SeleniumTest.Pages
{
	public class HomePage
	{
		public void LoadApplicationURL()
		{
			Driver.Instance.GoToUrl(Config.Url, "Mercury");
		}
	}
}