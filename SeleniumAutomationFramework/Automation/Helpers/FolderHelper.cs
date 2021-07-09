using System;
using System.IO;

namespace Automation.Helpers
{
	public class FolderHelper
	{
		internal static string CurrentProjectFolder
		{
			get
			{
				return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
			}
		}

		internal static string DefaultDriverFolder
		{
			get
			{
				return CreateFolder(Path.Combine(CurrentProjectFolder, "Resources\\"));
			}
		}

		internal static string DefaultLogsFolder
		{
			get
			{
				return CreateFolder(Path.Combine(CurrentProjectFolder, "TestOutput\\Logs\\"));
			}
		}

		internal static string DefaultReportsFolder
		{
			get
			{
				return CreateFolder(Path.Combine(CurrentProjectFolder, "TestOutput\\Reports\\"));
			}
		}

		internal static string DefaultScreenshotsFolder
		{
			get
			{
				return CreateFolder(Path.Combine(CurrentProjectFolder, "TestOutput\\Screenshots\\"));
			}
		}

		public static string CreateFolder(string path)
		{
			Directory.CreateDirectory(path);
			return path;
		}
	}
}