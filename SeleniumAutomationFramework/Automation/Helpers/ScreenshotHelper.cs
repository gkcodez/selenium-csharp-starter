using System.Drawing;
using System.IO;
using Automation.Base;
using OpenQA.Selenium;

namespace Automation.Helpers
{
	public static class ScreenshotHelper
	{
		internal static string screenshotPath { get; private set; }

		public static string Screenshot
		{
			get
			{
				if (Config.ScreenshotEnabled)
				{
					byte[] byteArray = ((ITakesScreenshot)Driver.Instance).GetScreenshot().AsByteArray;
					var bitmap = new Bitmap(new MemoryStream(byteArray));
					screenshotPath = Path.Combine(Config.ScreenshotPath, NameHelper.FullNameWithFormat(Config.ScreenshotFormat));
					bitmap.Save(screenshotPath);
					//string screenshotBytes = Convert.ToBase64String(byteArray);
					return screenshotPath;
				}
				else
				{
					return null;
				}
			}
		}

		public static byte[] GetBytes(this string screenshotpath)
		{
			byte[] imageData = File.ReadAllBytes(screenshotPath);
			return imageData;
		}

		//public static byte[] imageToByteArray(Image imageIn)
		//{
		//	MemoryStream ms = new MemoryStream();
		//	imageIn.Save(ms, ImageFormat.Gif);
		//	return ms.ToArray();
		//}

		//public static Image byteArrayToImage(byte[] byteArrayIn)
		//{
		//	MemoryStream ms = new MemoryStream(byteArrayIn);
		//	Image returnImage = Image.FromStream(ms);
		//	return returnImage;
		//}
	}
}