
//#define NEW

using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinMaxRange))]
public class MinMaxRangeDrawer : PropertyDrawer
{
	private static readonly GUIStyle MAX_LABEL_STYLE = new GUIStyle() { alignment = TextAnchor.MiddleRight };
	private static readonly GUIContent MIN_LABEL = new GUIContent("Min: ");
	private static readonly GUIContent MAX_LABEL = new GUIContent("Max: ");
	private static readonly float MIN_LABEL_WIDTH = EditorStyles.label.CalcSize(MIN_LABEL).x;
	private static readonly float MAX_LABEL_WIDTH = EditorStyles.label.CalcSize(MAX_LABEL).x;


	public MinMaxRangeDrawer() : base()
	{
		MAX_LABEL_STYLE.normal.textColor = EditorStyles.label.normal.textColor;
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		bool hasMinMaxRangeAttribute = TryGetMinMaxRangeAttribute(out _);
		float propertyHeight = base.GetPropertyHeight(property, label);

		return hasMinMaxRangeAttribute ?
			propertyHeight * 2.0f :
			propertyHeight;
	}

	public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
	{
		SerializedProperty min = property.FindPropertyRelative(nameof(MinMaxRange.Min));
		SerializedProperty max = property.FindPropertyRelative(nameof(MinMaxRange.Max));
		float newMin = min.floatValue;
		float newMax = max.floatValue;

		Rect contentRect = EditorGUI.PrefixLabel(rect, label);
		contentRect.height = base.GetPropertyHeight(property, label);

		if (TryGetMinMaxRangeAttribute(out MinMaxRangeAttribute range))
		{
			Rect sliderRect = new Rect(contentRect) { y = contentRect.y + contentRect.height };
			DrawSlider(sliderRect, range, ref newMin, ref newMax);
		}

		DrawValues(contentRect, ref newMin, ref newMax);

		SetNewValues(newMin, newMax, range, min, max);
	}

	private bool TryGetMinMaxRangeAttribute(out MinMaxRangeAttribute range)
	{
		object[] attributes = fieldInfo.GetCustomAttributes(typeof(MinMaxRangeAttribute), false);
		if (attributes?.Length > 0)
		{
			range = attributes[0] as MinMaxRangeAttribute;
			return true;
		}

		range = null;
		return false;
	}

	private static void DrawSlider(Rect rect, MinMaxRangeAttribute range, ref float newMin, ref float newMax)
	{
		const float c_spaceBetweenSliderAndValue = 10.0f;

		GUIContent minLabel = new GUIContent(range.Min.ToString("0.###"));
		float minLabelWidth = EditorStyles.label.CalcSize(minLabel).x;
		Rect minValueRect = new Rect(rect) { width = minLabelWidth };
		EditorGUI.LabelField(minValueRect, minLabel);

		GUIContent maxLabel = new GUIContent(range.Max.ToString("0.###"));
		float maxLabelWidth = MAX_LABEL_STYLE.CalcSize(maxLabel).x;
		EditorGUI.LabelField(new Rect(rect.xMax - maxLabelWidth, rect.y, maxLabelWidth, rect.height), maxLabel, MAX_LABEL_STYLE);

		float sliderPositionX = minValueRect.xMax + c_spaceBetweenSliderAndValue;
		float sliderWidth = rect.width - minLabelWidth - maxLabelWidth - (c_spaceBetweenSliderAndValue * 2.0f);
		EditorGUI.MinMaxSlider(new Rect(sliderPositionX, rect.y, sliderWidth, rect.height), ref newMin, ref newMax, range.Min, range.Max);
	}

	private static void DrawValues(Rect rect, ref float newMin, ref float newMax)
	{
		const float c_spaceBetweenMinAndMax = 10.0f;
		const float c_spaceBetweenLabelAndValue = 5.0f;

		float floatFieldWidth = (rect.width - c_spaceBetweenMinAndMax) * 0.5f;

		EditorGUIUtility.labelWidth = MIN_LABEL_WIDTH + c_spaceBetweenLabelAndValue;
		Rect minFloatFieldRect = new Rect(rect) { width = floatFieldWidth };
		newMin = EditorGUI.FloatField(minFloatFieldRect, MIN_LABEL, newMin);

		EditorGUIUtility.labelWidth = MAX_LABEL_WIDTH + c_spaceBetweenLabelAndValue;
		Rect maxFloatFieldRect = new Rect(minFloatFieldRect) { x = minFloatFieldRect.xMax + c_spaceBetweenMinAndMax };
		newMax = EditorGUI.FloatField(maxFloatFieldRect, MAX_LABEL, newMax);
	}

	private void SetNewValues(float newMin, float newMax, MinMaxRangeAttribute range, SerializedProperty min, SerializedProperty max)
	{
		if (range != null)
		{
			newMin = Mathf.Clamp(newMin, range.Min, newMax);
			newMax = Mathf.Clamp(newMax, newMin, range.Max);
		}
		else
		{
			newMax = Mathf.Max(newMin, newMax);
			newMin = Mathf.Min(newMin, newMax);
		}

		min.floatValue = newMin;
		max.floatValue = newMax;
	}
}
