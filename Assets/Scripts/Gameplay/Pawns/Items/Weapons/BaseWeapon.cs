
using Sirenix.OdinInspector;
using UnityEngine;


public abstract class BaseWeapon : BasePawn, IPickUpItem, IDroppableItem
{
#region Fields (serialized)

	[SerializeField]
	[Required]
	protected WeaponDescriptor m_descriptor = null;

	[SerializeField]
	[Required]
	private Collider m_pickUpCollider = null;

	[SerializeField]
	private Transform m_groundAnchor = null;

	#endregion

#region Fields (protected)

	protected float m_lastUseTime = 0.0f;

	#endregion


	public bool DefaultsToRightHand()
	{
		return m_descriptor.DefaultsToRightHand;
	}

	void IPickUpItem.PickUp(BasePawn pawn)
	{
		m_pickUpCollider.enabled = false;
	}

	void IDroppableItem.Drop()
	{
		m_pickUpCollider.enabled = true;
	}

	public abstract void UseWeapon();
}
