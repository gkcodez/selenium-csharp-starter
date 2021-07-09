using System;
using System.Linq;
using Automation.Attributes;

namespace Automation.Helpers
{
	public static class AttributeHelper
	{
		private static TAttribute GetEnumAttribute<TAttribute>(object value) where TAttribute : Attribute
		{
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			var myAttribute = type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
			return myAttribute;
		}

		public static string Value(this Enum value)
		{
			var enumValue = GetEnumAttribute<EnumAttribute>(value);
			return enumValue != null ? enumValue.Value : null;
		}

		public static string TargetName(this Enum value)
		{
			var enumValue = GetEnumAttribute<EnumAttribute>(value);
			return enumValue != null ? enumValue.TargetName : null;
		}
	}
}