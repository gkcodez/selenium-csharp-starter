using System;

namespace Automation.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class EnumAttribute : Attribute
	{
		public string Value { get; set; }
		public string TargetName { get; set; }
	}
}