
using Nrjwolf.Tools.AttachAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementComponent : MonoBehaviour
{
#region Fields (serialized)

	[SerializeField]
	[Required]
	[GetComponent]
	private Rigidbody m_rigidbody = null;

	[SerializeField]
	private float m_speed = 5.0f;

	#endregion

#region Fields (private)

	private IA_PlayerMovement m_inputActions = null;
	private Vector3 m_movementDirection = Vector3.zero;

	#endregion


	private void Awake()
	{
		InitializeInputs();
	}

	private void InitializeInputs()
	{
		m_inputActions = new IA_PlayerMovement();
		m_inputActions.Enable();

		m_inputActions.Movement.Movement.started += UpdateMovementDirection;
		m_inputActions.Movement.Movement.performed += UpdateMovementDirection;
		m_inputActions.Movement.Movement.canceled += UpdateMovementDirection;
	}

	private void OnEnable()
	{
		m_inputActions.Enable();
	}

	private void OnDisable()
	{
		m_inputActions.Disable();
	}

	private void Update()
	{
		if (m_movementDirection != Vector3.zero)
			Move();

		LookAtMouse();
	}

	private void UpdateMovementDirection(CallbackContext input)
	{
		m_movementDirection = input.ReadValue<Vector2>().xzy();
	}

	private void Move()
	{
		Vector3 directionInCameraSpace = GameCamera.ActiveCamera.TransformDirection(m_movementDirection);

		transform.Translate(directionInCameraSpace * (m_speed * Time.deltaTime), Space.World);
	}

	private void LookAtMouse()
	{
		Vector3 relativeMousePosition = GameCamera.ActiveCamera.GetMouseRelativePosition(transform.position);
		transform.LookAt(transform.position + relativeMousePosition, Vector3.up);
	}
}
