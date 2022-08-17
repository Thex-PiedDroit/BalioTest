
using UnityEngine;


[System.Serializable]
public struct MinMaxRangeInt
{
	public int Min;
	public int Max;

	/// <summary>
	/// The delta between Max and Min.
	/// </summary>
	public int Spread => Max - Min;


	public MinMaxRangeInt(int min, int max)
	{
		Min = min;
		Max = max;
	}

	public MinMaxRangeInt(MinMaxRangeInt other)
	{
		Min = other.Min;
		Max = other.Max;
	}

	/// <summary>
	/// Returns a random value within the Min and Max values of this range.
	/// </summary>
	public int GetRandom()
	{
		return Random.Range(Min, Max);
	}

	static public bool operator >(MinMaxRangeInt range, int value)
	{
		return range.Max > value;
	}
	static public bool operator <(MinMaxRangeInt range, int value)
	{
		return range.Min < value;
	}
	static public bool operator >=(MinMaxRangeInt range, int value)
	{
		return range.Max >= value;
	}
	static public bool operator <=(MinMaxRangeInt range, int value)
	{
		return range.Min <= value;
	}
}
