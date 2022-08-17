
using Sirenix.OdinInspector;
using UnityEngine;


public class Projectile : BasePawn
{
#region Fields (serialized)

	[SerializeField]
	private ProjectileDescriptor m_descriptor = null;

	[SerializeField]
	[Required]
	private Rigidbody m_rigidBody = null;

	#endregion

	#region Fields (private)

	private float m_damage = 0.0f;

	private float m_startTime = 0.0f;

	#endregion


	public void Initialize(float damage)
	{
		m_damage = damage;

		m_rigidBody.AddRelativeForce(Vector3.forward * m_descriptor.ShootForce, ForceMode.Impulse);
		m_startTime = Time.time;
	}

	private void Update()
	{
		if (m_startTime != 0.0f &&
			Time.time - m_startTime >= m_descriptor.MaxLifeTime)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		// TODO: GetComponent on collision for IDamageable

		m_rigidBody.isKinematic = true;	// Quick last second hack to freeze it on impact for fun
	}
}
