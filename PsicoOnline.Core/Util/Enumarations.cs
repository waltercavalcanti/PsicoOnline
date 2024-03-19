using System.ComponentModel;
using System.Reflection;

namespace PsicoOnline.Core.Util;

public static class Enumarations
{
	public static string RetornaDescricaoEnum(Enum value)
	{
		if (value == null)
		{
			return string.Empty;
		}

		FieldInfo fi = value.GetType().GetField(value.ToString());

		DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

		return attributes != null && attributes.Any()
			? attributes.First().Description
			: value.ToString();
	}
}