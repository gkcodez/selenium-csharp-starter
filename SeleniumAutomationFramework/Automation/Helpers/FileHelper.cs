using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Automation.Enums;

namespace Automation.Helpers
{
	public class FileHelper
	{
		public static string ReadFileFromDll(string nameSpace, string filename)
		{
			string result = string.Empty;
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = string.Format("{0}.{1}", nameSpace, filename);

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					result = reader.ReadToEnd();
				}
				return result;
			}
		}

		public static List<string> GetFilesFromFolder(string excelFolder)
		{
			List<string> files = new List<string>();
			DirectoryInfo directory = new DirectoryInfo(excelFolder);
			foreach (var file in directory.GetFiles("*.*"))
			{
				files.Add(file.FullName);
			}
			return files;
		}

		public static List<string> GetFilesFromFolderInFormat(string excelFolder, FileFormat format)
		{
			List<string> files = new List<string>();
			DirectoryInfo directory = new DirectoryInfo(excelFolder);
			foreach (var file in directory.GetFiles($"*{format.Value()}"))
			{
				files.Add(file.FullName);
			}
			return files;
		}
	}
}