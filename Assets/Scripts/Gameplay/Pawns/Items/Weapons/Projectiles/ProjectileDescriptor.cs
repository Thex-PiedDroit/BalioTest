
using UnityEngine;


[CreateAssetMenu(fileName = ASSET_PREFIX, menuName = ASSET_MENU_PATH)]
public class ProjectileDescriptor : ScriptableObject
{
#region Fields (serialized)

	[field: SerializeField]
	public float ShootForce { get; private set; } = 0.0f;

	[field: SerializeField]
	public float MaxLifeTime { get; private set; } = 1.0f;

	#endregion

#region Fields (private)

	private const string ASSET_PREFIX = "ProjD_";
	private const string ASSET_MENU_PATH = "ScriptableObjects/Weapons/Projectile Descriptor";

	#endregion



}
