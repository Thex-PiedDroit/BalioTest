
using System;
using UnityEngine;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class MinMaxRangeAttribute : PropertyAttribute
{
	public float Min = 0.0f;
	public float Max = 0.0f;

	public MinMaxRangeAttribute(float min, float max)
	{
		Min = min;
		Max = max;
	}
}
