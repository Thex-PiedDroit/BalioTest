
using System;
using UnityEngine;


public static class BaseTypesExtensions
{
	static public int Sqrd(this int value)
	{
		return value * value;
	}

	static public float Sqrd(this float value)
	{
		return value * value;
	}
}

public static class StringExtensions
{
	public static T ToEnum<T>(this string str, T defaultValue) where T : Enum
	{
		if (string.IsNullOrEmpty(str))
			return defaultValue;

		Enum[] allValues = (Enum[])(Enum.GetValues(typeof(Enum)));

		for (int i = 0, n = allValues.Length; i < n; ++i)
		{
			Enum enumValue = allValues[i];

			if (enumValue.ToString().ToLower() == str.ToLower())
				return (T)enumValue;
		}

		Debug.LogError($"Could not find matching value for \"{str} in enum \"{typeof(T)}\"!");
		return defaultValue;
	}
}
