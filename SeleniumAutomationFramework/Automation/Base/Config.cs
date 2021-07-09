using System;
using System.Configuration;
using System.IO;
using Automation.Enums;
using Automation.Extensions;
using Automation.Helpers;

namespace Automation.Base
{
	public class Config
	{
		public static string AppName => ConfigurationManager.AppSettings["appname"];

		public static string Url => ConfigurationManager.AppSettings["url"];

		public static Browser TestBrowser
		{
			get
			{
				Browser browser;
				bool supportedBrowser = Enum.TryParse(ConfigurationManager.AppSettings["browser"], out browser);
				if (supportedBrowser)
				{
					return browser;
				}
				return Browser.Chrome;
			}
		}

		public static string DriverPath
		{
			get
			{
				string driverPath = ConfigurationManager.AppSettings["driverpath"];
				if (!string.IsNullOrEmpty(driverPath))
				{
					if (Path.IsPathRooted(driverPath))
					{
						return FolderHelper.CreateFolder(driverPath);
					}
					else
					{
						return FolderHelper.CreateFolder(Path.Combine(FolderHelper.CurrentProjectFolder, driverPath));
					}
				}
				return FolderHelper.DefaultLogsFolder;
			}
		}

		public static int TimeoutShort
		{
			get
			{
				int timeout = 30;

				try
				{
					timeout = int.Parse(ConfigurationManager.AppSettings["timeoutshort"]);
				}
				catch (Exception)
				{
				}
				return timeout;
			}
		}

		public static int TimeoutMedium
		{
			get
			{
				int timeout = 60;

				try
				{
					timeout = int.Parse(ConfigurationManager.AppSettings["timeoutmedium"]);
				}
				catch (Exception)
				{
				}
				return timeout;
			}
		}

		public static int TimeoutLong
		{
			get
			{
				int timeout = 90;

				try
				{
					timeout = int.Parse(ConfigurationManager.AppSettings["timeoutlong"]);
				}
				catch (Exception)
				{
				}
				return timeout;
			}
		}

		public static bool LogEnabled
		{
			get
			{
				try
				{
					return bool.Parse(ConfigurationManager.AppSettings["logenabled"]);
				}
				catch (Exception)
				{
					return true;
				}
			}
		}

		public static string LogPath
		{
			get
			{
				string logPath = ConfigurationManager.AppSettings["logpath"];
				if (!string.IsNullOrEmpty(logPath))
				{
					if (Path.IsPathRooted(logPath))
					{
						return FolderHelper.CreateFolder(logPath);
					}
					else
					{
						return FolderHelper.CreateFolder(Path.Combine(FolderHelper.CurrentProjectFolder, logPath));
					}
				}
				return FolderHelper.DefaultLogsFolder;
			}
		}

		public static LogFormat LogFormat
		{
			get
			{
				LogFormat logFormat;
				bool parseSuccess = Enum.TryParse(ConfigurationManager.AppSettings["logformat"].ToPascal(), out logFormat);

				if (parseSuccess)
				{
					return (LogFormat)Enum.Parse(typeof(LogFormat), ConfigurationManager.AppSettings["logformat"].ToPascal());
				}
				return LogFormat.Txt;
			}
		}

		public static bool ReportEnabled
		{
			get
			{
				try
				{
					return bool.Parse(ConfigurationManager.AppSettings["reportenabled"]);
				}
				catch (Exception)
				{
					return true;
				}
			}
		}

		public static string ReportPath
		{
			get
			{
				string reportPath = ConfigurationManager.AppSettings["reportpath"];
				if (!string.IsNullOrEmpty(reportPath))
				{
					if (Path.IsPathRooted(reportPath))
					{
						return FolderHelper.CreateFolder(reportPath);
					}
					else
					{
						return FolderHelper.CreateFolder(Path.Combine(FolderHelper.CurrentProjectFolder, reportPath));
					}
				}
				return FolderHelper.DefaultReportsFolder;
			}
		}

		public static bool ScreenshotEnabled
		{
			get
			{
				try
				{
					return bool.Parse(ConfigurationManager.AppSettings["screenshotenabled"]);
				}
				catch (Exception)
				{
					return true;
				}
			}
		}

		public static string ScreenshotPath
		{
			get
			{
				string screenshotPath = ConfigurationManager.AppSettings["screenshotpath"];
				if (!string.IsNullOrEmpty(screenshotPath))
				{
					if (Path.IsPathRooted(screenshotPath))
					{
						return FolderHelper.CreateFolder(screenshotPath);
					}
					else
					{
						return FolderHelper.CreateFolder(Path.Combine(FolderHelper.CurrentProjectFolder, screenshotPath));
					}
				}
				return FolderHelper.DefaultScreenshotsFolder;
			}
		}

		public static ImageFormat ScreenshotFormat
		{
			get
			{
				ImageFormat screenshotFormat;
				bool parseSuccess = Enum.TryParse(ConfigurationManager.AppSettings["screenshotformat"], out screenshotFormat);

				if (parseSuccess)
				{
					return (ImageFormat)Enum.Parse(typeof(ImageFormat), ConfigurationManager.AppSettings["screenshotformat"]);
				}
				return ImageFormat.Png;
			}
		}

		public static string ConnectionString
		{
			get
			{
				string connectionString = ConfigurationManager.ConnectionStrings["Automation"].ConnectionString != null ? ConfigurationManager.ConnectionStrings["Automation"].ConnectionString : string.Empty;
				return connectionString;
			}
		}
	}
}