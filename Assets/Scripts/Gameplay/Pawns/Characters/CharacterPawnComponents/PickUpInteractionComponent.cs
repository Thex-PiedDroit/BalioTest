
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PickUpInteractionComponent : MonoBehaviour
{
#region Fields (public)

	public Action<IPickUpItem> OnPickUpItemDetected;
	public Action<IPickUpItem> OnPickUpItemDisappeared;

	#endregion

	#region Fields (serialized)

	[SerializeField]
	[Required]
	private BasePawn m_owner = null;

	#endregion

#region Fields (private)

	// Wanted to have a queue here but need random access to remove items, and there's not enough time to figure out a solution, so switching to single item
	private IPickUpItem m_itemInRange = null;

	private IA_PlayerInteraction m_inputActions = null;

	#endregion


	private void Awake()
	{
		InitializeInputs();
	}

	private void InitializeInputs()
	{
		m_inputActions = new IA_PlayerInteraction();

		m_inputActions.Interaction.Interact.started += PickUpCurrentItem;

		m_inputActions.Enable();
	}

	public void PickUpCurrentItem(CallbackContext input)
	{
		IPickUpItem item = m_itemInRange;

		item.PickUp(m_owner);

		if (m_owner is IItemHolder itemHolder)
			itemHolder.GiveItem(item);
	}

	private void OnTriggerEnter(Collider other)
	{
		BasePawn pawn = other.GetComponent<BasePawn>();

		if (pawn != null && pawn is IPickUpItem item)
		{
			OnPickUpItemDetected?.Invoke(item);
			m_itemInRange = item;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		BasePawn pawn = other.GetComponent<BasePawn>();

		if (pawn != null && pawn is IPickUpItem item)
		{
			OnPickUpItemDisappeared?.Invoke(item);
			m_itemInRange = null;
		}
	}
}
