using Automation.Attributes;

namespace Automation.Enums
{
	public enum LogFormat
	{
		/// <summary>
		/// Text Format
		/// </summary>
		[Enum(Value = ".txt", TargetName = "txtlogfile")]
		Txt = 0,

		/// <summary>
		/// Html Format
		/// </summary>
		[Enum(Value = ".csv", TargetName = "csvlogfile")]
		Csv = 1,
	}
}