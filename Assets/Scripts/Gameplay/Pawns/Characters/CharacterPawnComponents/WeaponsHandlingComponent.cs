
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class WeaponsHandlingComponent : MonoBehaviour
{
#region Fields (serialized)

	[SerializeField]
	protected CharacterHand m_handRight = null;

	[SerializeField]
	protected CharacterHand m_handLeft = null;

	#endregion

#region Fields (private)

	// Not enough time left to properly implement support for two weapons, adding this here to force only 1 weapon held at a time
	private BaseWeapon m_currentWeapon = null;

	private IA_PlayerCombat m_inputActions = null;

	private bool m_isAttacking = false;

	#endregion


	private void Awake()
	{
		InitializeInputs();
	}

	private void InitializeInputs()
	{
		m_inputActions = new IA_PlayerCombat();

		m_inputActions.Combat.Attack.started += UseCurrentWeapon;
		m_inputActions.Combat.Attack.canceled += StopAttack;

		m_inputActions.Enable();
	}

	private void Update()
	{
		if (m_isAttacking && m_currentWeapon != null)
			m_currentWeapon.UseWeapon();
	}

	public bool TryEquipWeapon(BaseWeapon weapon)
	{
		// Ugly but not enough time left to spend it on cleaning this up right now
		// TODO: Simplify this

		if (m_currentWeapon != null)
			return false;

		if (weapon.DefaultsToRightHand())
		{
			if (!m_handRight.HasWeaponEquipped())
			{
				EquipWeapon(weapon, m_handRight);
				return true;
			}
			else if (!m_handLeft.HasWeaponEquipped())
			{
				EquipWeapon(weapon, m_handLeft);
				return true;
			}
		}
		else
		{
			if (!m_handLeft.HasWeaponEquipped())
			{
				EquipWeapon(weapon, m_handLeft);
				return true;
			}
			else if (!m_handRight.HasWeaponEquipped())
			{
				EquipWeapon(weapon, m_handRight);
				return true;
			}
		}

		return false;
	}

	private void EquipWeapon(BaseWeapon weapon, CharacterHand hand)
	{
		hand.EquipWeapon(weapon);
		m_currentWeapon = weapon;
	}

	public void UseRightHand()
	{
		UseCurrentWeapon();
	}

	public void UseLeftHand()
	{
		UseCurrentWeapon();
	}

	private void UseCurrentWeapon(CallbackContext input = default)
	{
		m_isAttacking = true;
	}

	private void StopAttack(CallbackContext input = default)
	{
		m_isAttacking = false;
	}
}
