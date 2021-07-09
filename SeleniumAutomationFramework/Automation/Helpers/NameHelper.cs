using System;
using Automation.Base;
using Automation.Enums;

namespace Automation.Helpers
{
	internal class NameHelper
	{
		public static string FullName
		{
			get
			{
				return $"{Config.AppName}_{DateTime.Now.ToString("dd-MM-yyy_HH-mm-ss-mmm")}";
			}
		}

		public static string FullNameWithFormat(FileFormat format)
		{
			return $"{FullName}{format.Value()}";
		}

		public static string FullNameWithFormat(ImageFormat format)
		{
			return $"{FullName}{format.Value()}";
		}
	}
}