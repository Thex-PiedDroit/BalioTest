
using UnityEngine;


public class CharacterHand : MonoBehaviour
{
#region Fields (serialized)



	#endregion

#region Fields (private)

	private BaseWeapon m_equippedWeapon = null;

	#endregion


	public bool HasWeaponEquipped()
	{
		return m_equippedWeapon != null;
	}

	public void EquipWeapon(BaseWeapon weapon)
	{
		m_equippedWeapon = weapon;

		weapon.transform.parent = transform;
		weapon.transform.localPosition = Vector3.zero;
		weapon.transform.localRotation = Quaternion.identity;
	}

	public void UnequipCurrentWeapon()
	{
		m_equippedWeapon = null;

		// TODO: Add drop behaviour (unparent + set position/rotation)
	}
}
