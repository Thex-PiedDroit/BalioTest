
using Sirenix.OdinInspector;
using System;
using UnityEngine;


[CreateAssetMenu(fileName = ASSET_PREFIX + DESCRIPTOR_DISPLAY_NAME, menuName = ASSET_MENU_PATH + DESCRIPTOR_DISPLAY_NAME)]
public class CBD_IsometricStyle : CameraBehaviourDescriptor
{
#region Fields (public)

	public override Type BehaviourType => typeof(CB_IsometricStyle);

	#endregion

#region Fields (serialized)

	[field: SerializeField]
	public Vector3 OffsetFromTarget { get; private set; } = Vector3.zero;

	[field: SerializeField]
	public Vector3 DefaultRotation { get; private set; } = Vector3.zero;

	[field: SerializeField]
	[field: MinValue(0.0f)]
	public float MaxMouseDistanceForLookup { get; private set; } = 10.0f;

	[field: SerializeField]
	[field: PropertyRange(0.0f, 1.0f)]
	public float LookupDistanceFromMouse { get; private set; } = 0.33f;

	[field: SerializeField]
	[field: MinMaxRange(0.0f, 1.0f)]
	public MinMaxRange SmoothFollowFactor { get; private set; } = new(0.1f, 0.5f);

	#endregion

#region Fields (private)

	private const string DESCRIPTOR_DISPLAY_NAME = "IsometricStyle";

	#endregion



}
