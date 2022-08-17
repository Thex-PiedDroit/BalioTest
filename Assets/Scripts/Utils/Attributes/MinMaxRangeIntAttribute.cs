
using System;
using UnityEngine;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class MinMaxRangeIntAttribute : PropertyAttribute
{
	public int Min = 0;
	public int Max = 0;

	public MinMaxRangeIntAttribute(int min, int max)
	{
		Min = min;
		Max = max;
	}
}
