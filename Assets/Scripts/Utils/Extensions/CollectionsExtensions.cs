
using System;
using System.Collections.Generic;


static public class ListsExtensions
{
	static public T GetRandomElement<T>(this IReadOnlyList<T> list)
	{
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	static public void RemoveSwapLast<T>(this IList<T> list, int index)
	{
		int lastItemIndex = list.Count - 1;

		list[index] = list[lastItemIndex];
		list.RemoveAt(lastItemIndex);
	}
}

static public class DictionariesExtensions
{
	static public TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
	{
		if (!dictionary.TryGetValue(key, out TValue value))
		{
			value = new();
			dictionary.Add(key, value);
		}

		return value;
	}

	static public void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<TValue> values, Func<TValue, TKey> keySelector)
	{
		foreach (TValue value in values)
		{
			TKey key = keySelector(value);
			dictionary.Add(key, value);
		}
	}
}
