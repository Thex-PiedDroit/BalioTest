
using Nrjwolf.Tools.AttachAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameCamera : MonoBehaviour
{
#region Fields (public)

	public static GameCamera ActiveCamera { get; private set; } = null;

	#endregion

#region Fields (serialized)

	[SerializeField]
	[Required]
	[GetComponent]
	private Camera m_cameraComponent = null;

	[SerializeField]
	private CameraBehaviourDescriptor m_cameraBehaviourDescriptor = null;

	[SerializeField]
	private bool m_isInitialCameraForCurrentMap = false;

	#endregion

#region Fields (private)

	private ICameraBehaviour m_behaviour = null;

	private BasePawn m_target = null;

	private bool m_isActive = false;

	#endregion


	private void Awake()
	{
		m_behaviour = CameraBehaviourFactory.CreateBehaviour(m_cameraBehaviourDescriptor, this);

		if (m_isInitialCameraForCurrentMap)
		{
			if (ActiveCamera == null)
			{
				ActiveCamera = this;
				m_isActive = true;
			}
			else
			{
				Debug.LogError($"More than one camera are tagged as initial camera for current level. Please make sure there is only one. Current instance is {ActiveCamera} and current duplicate is {this}.");
			}
		}

		m_cameraComponent.gameObject.SetActive(m_isActive);
	}

	private void Update()
	{
		if (m_cameraComponent.gameObject.activeSelf)
			m_behaviour?.UpdateBehaviour(m_target);
	}

	public void SetTarget(BasePawn target)
	{
		m_target = target;

		if (m_isActive)
			m_behaviour.Initialize();
	}

	public void SetActive(bool isActive)
	{
		m_isActive = isActive;

		if (isActive)
			m_behaviour.Initialize();
	}

	public Vector3 GetMouseRelativePosition(Vector3 fromPosition)
	{
		Vector3 mousePosOnGround = GetMousePositionOnGround(fromPosition);
		return mousePosOnGround - fromPosition;
	}

	private Vector3 GetMousePositionOnGround(Vector3 fromPosition)
	{
		Ray mouseRay = m_cameraComponent.ScreenPointToRay(Mouse.current.position.ReadValue());
		float multiplier = (transform.position.y - fromPosition.y) / Vector3.Dot(mouseRay.direction, Vector3.down);

		return transform.position + (mouseRay.direction * multiplier);
	}

	public Vector3 TransformDirection(Vector3 direction)
	{
		return transform.TransformDirection(direction).x_z().normalized;
	}
}
