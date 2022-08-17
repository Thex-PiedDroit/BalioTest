
using UnityEngine;


[CreateAssetMenu(fileName = ASSET_PREFIX, menuName = ASSET_MENU_PATH)]
public class WeaponDescriptor : ScriptableObject
{
#region Fields (serialized)

	[field: SerializeField]
	[field: Tooltip("Defaults to left if false")]
	public bool DefaultsToRightHand { get; private set; } = true;

	[field: SerializeField]
	public float AttacksDelay { get; private set; } = 0.0f;

	#endregion

#region Fields (private)

	private const string ASSET_PREFIX = "WD_";
	private const string ASSET_MENU_PATH = "ScriptableObjects/Weapons/Weapon Descriptor";

	#endregion
}
