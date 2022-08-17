
using Sirenix.OdinInspector;
using UnityEngine;


public class RangedWeapon : BaseWeapon
{
	#region Fields (serialized)

	[SerializeField]
	private Projectile m_projectilePrefab = null;

	[SerializeField]
	[Required]
	private Transform m_projectileOrigin = null;

	#endregion

#region Fields (private)



	#endregion


	public override void UseWeapon()
	{
		if (Time.time - m_lastUseTime >= m_descriptor.AttacksDelay)
		{
			LaunchProjectile();

			m_lastUseTime = Time.time;
		}
	}

	private void LaunchProjectile()
	{
		Projectile projectile = Instantiate(m_projectilePrefab, m_projectileOrigin.position, m_projectileOrigin.rotation);

		projectile.Initialize(damage: 0.0f);
	}
}
