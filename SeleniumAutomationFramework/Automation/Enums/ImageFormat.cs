using Automation.Attributes;

namespace Automation.Enums
{
	public enum ImageFormat
	{
		/// <summary>
		/// Jpg Format
		/// </summary>
		[Enum(Value = ".jpg")]
		Jpeg = 1,

		/// <summary>
		/// Png Format
		/// </summary>
		[Enum(Value = ".png")]
		Png = 2,

		/// <summary>
		/// Gif Format
		/// </summary>
		[Enum(Value = ".gif")]
		Gif = 3,

		/// <summary>
		///Bmp Format
		/// </summary>
		[Enum(Value = ".bmp")]
		Bmp = 4
	}
}