
using UnityEngine;


public class Character : BasePawn, IItemHolder
{
	#region Fields (serialized)

	[SerializeField]
	private WeaponsHandlingComponent m_weaponsHandlingComponent = null;

	#endregion

#region Fields (private)



	#endregion


	void IItemHolder.GiveItem(IPickUpItem item)
	{
		if (item is BaseWeapon weapon && m_weaponsHandlingComponent != null)
		{
			m_weaponsHandlingComponent.TryEquipWeapon(weapon);
		}
	}
}
