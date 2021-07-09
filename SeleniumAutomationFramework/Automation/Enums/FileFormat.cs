using Automation.Attributes;

namespace Automation.Enums
{
	public enum FileFormat
	{
		/// <summary>
		/// Text Format
		/// </summary>
		[Enum(Value = ".txt")]
		Txt = 0,

		/// <summary>
		/// Html Format
		/// </summary>
		[Enum(Value = ".html")]
		Html = 1,

		/// <summary>
		/// Jpg Format
		/// </summary>
		[Enum(Value = ".jpg")]
		Jpeg = 2,

		/// <summary>
		/// Png Format
		/// </summary>
		[Enum(Value = ".png")]
		Png = 3
	}
}