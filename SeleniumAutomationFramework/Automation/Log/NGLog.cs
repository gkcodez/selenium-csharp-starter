using System;
using System.IO;
using Automation.Base;
using Automation.Helpers;
using NLog;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace Automation.Log
{
	public class NGLog
	{
		private static Logger logger;

		static NGLog()
		{
			Initialize();
		}

		private static void Initialize()
		{
			if (Config.LogEnabled)
			{
				logger = LogManager.GetCurrentClassLogger();
				if (LogManager.Configuration != null && LogManager.Configuration.ConfiguredNamedTargets.Count != 0)
				{
					Target target = LogManager.Configuration.FindTargetByName(Config.LogFormat.TargetName());
					if (target == null)
					{
						throw new Exception("Could not find target named: " + "file");
					}

					FileTarget fileTarget = null;
					WrapperTargetBase wrapperTarget = target as WrapperTargetBase;

					if (wrapperTarget == null)
					{
						fileTarget = target as FileTarget;
					}
					else
					{
						fileTarget = wrapperTarget.WrappedTarget as FileTarget;
					}

					if (fileTarget == null)
					{
						throw new Exception("Could not get a FileTarget from " + target.GetType());
					}
					string filename = Path.Combine(Config.LogPath, NameHelper.FullName + Config.LogFormat.Value());
					if (!File.Exists(filename))
					{
						File.Create(filename).Close();
					}
					fileTarget.FileName = filename;
					fileTarget.Layout = fileTarget.Layout;
					LogManager.ReconfigExistingLoggers();
				}
			}
		}

		public static void Info(string message)
		{
			if (Config.LogEnabled)
			{
				if (logger != null)
				{
					logger.Info(message);
				}
			}
		}

		public static void Warn(string message)
		{
			if (Config.LogEnabled)
			{
				if (logger != null)
				{
					logger.Warn(message);
				}
			}
		}

		public static void Error(string message)
		{
			if (Config.LogEnabled)
			{
				if (logger != null)
				{
					logger.Error(message);
				}
			}
		}
	}
}