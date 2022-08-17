
using System;
using UnityEngine;


public abstract class CameraBehaviourDescriptor : ScriptableObject
{
#region Fields (public)

	public abstract Type BehaviourType { get; }

	#endregion

#region Fields (protected)

	protected const string ASSET_PREFIX = "CBD_";
	protected const string ASSET_MENU_PATH = "ScriptableObjects/Camera Behaviour Descriptors/";

	#endregion
}
