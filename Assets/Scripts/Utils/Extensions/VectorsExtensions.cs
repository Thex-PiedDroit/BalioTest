
using UnityEngine;


public static class Vec2Extensions
{
#pragma warning disable IDE1006 // Naming Styles
	public static Vector3 xyz(this Vector2 vec)
	{
		return vec; // Yep...
	}

	public static Vector3 xzy(this Vector2 vec)
	{
		return new Vector3(vec.x, 0.0f, vec.y);
	}

	public static Vector2 x_(this Vector2 vec)
	{
		return new Vector2(vec.x, 0.0f);
	}

	public static Vector2 _y(this Vector2 vec)
	{
		return new Vector2(0.0f, vec.y);
	}
#pragma warning restore IDE1006 // Naming Styles


	public static Vector2 ShiftX(this Vector2 vec, float offsetX)
	{
		vec.x += offsetX;
		return vec;
	}

	public static Vector2 ShiftY(this Vector2 vec, float offsetY)
	{
		vec.x += offsetY;
		return vec;
	}

	public static Vector2 ShiftXY(this Vector2 vec, Vector2 offset)
	{
		vec += offset;
		return vec;
	}

	public static Vector2 SetX(this Vector2 vec, float x)
	{
		vec.x = x;
		return vec;
	}

	public static Vector2 SetY(this Vector2 vec, float y)
	{
		vec.y = y;
		return vec;
	}

	public static Vector2 Clamp(this Vector2 vec, Vector2 min, Vector2 max)
	{
		vec.x = Mathf.Clamp(vec.x, min.x, max.x);
		vec.y = Mathf.Clamp(vec.y, min.y, max.y);

		return vec;
	}
}

public static class Vec3Extensions
{
#pragma warning disable IDE1006 // Naming Styles
	public static Vector2 xy(this Vector3 vec)
	{
		return vec;
	}

	public static Vector3 xzy(this Vector3 vec)
	{
		return new Vector3(vec.x, vec.z, vec.y);
	}

	public static Vector3 xyz(this Vector3 vec)
	{
		return new Vector3(vec.x, vec.y, vec.z);
	}

	public static Vector3 x_z(this Vector3 vec)
	{
		return new Vector3(vec.x, 0.0f, vec.z);
	}

	public static Vector3 xy_(this Vector3 vec)
	{
		return new Vector3(vec.x, vec.y);
	}

	public static Vector3 _yz(this Vector3 vec)
	{
		return new Vector3(0.0f, vec.y, vec.z);
	}

	public static Vector3 x_y(this Vector3 vec)
	{
		return new Vector3(vec.x, 0.0f, vec.y);
	}
#pragma warning restore IDE1006 // Naming Styles

	public static Vector3 ShiftX(this Vector3 vec, float offsetX)
	{
		vec.x += offsetX;
		return vec;
	}

	public static Vector3 ShiftY(this Vector3 vec, float offsetY)
	{
		vec.x += offsetY;
		return vec;
	}

	public static Vector3 ShiftZ(this Vector3 vec, float offsetZ)
	{
		vec.x += offsetZ;
		return vec;
	}

	public static Vector3 ShiftXYZ(this Vector3 vec, Vector3 offset)
	{
		vec += offset;
		return vec;
	}

	public static Vector3 SetX(this Vector3 vec, float x)
	{
		vec.x = x;
		return vec;
	}

	public static Vector3 SetY(this Vector3 vec, float y)
	{
		vec.y = y;
		return vec;
	}

	public static Vector3 SetZ(this Vector3 vec, float z)
	{
		vec.z = z;
		return vec;
	}

	public static Vector3 Clamp(this Vector3 vec, Vector3 min, Vector3 max)
	{
		vec.x = Mathf.Clamp(vec.x, min.x, max.x);
		vec.y = Mathf.Clamp(vec.y, min.y, max.y);
		vec.z = Mathf.Clamp(vec.z, min.z, max.z);

		return vec;
	}
}
