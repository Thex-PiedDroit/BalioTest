
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


	[Header("Movement")]

	[SerializeField]
	private float m_speed = 5.0f;

	[SerializeField]
	[MinValue(0.0f)]
	private float m_jumpForce = 10.0f;

	[SerializeField]
	[MinValue(0.0f)]
	private float m_longJumpForceAscending = 10.0f;

	[SerializeField]
	[MinValue(0.0f)]
	private float m_longJumpForceDescending = 20.0f;


	[Header("Ground Check")]

	[SerializeField]
	private LayerMask m_groundCheckLayerMask = 0;

	[SerializeField]
	[MinValue(0.0f)]
	private float m_groundCheckSphereRadius = 0.5f;

	[SerializeField]
	[MinValue(0.0f)]
	private float m_groundCheckDistanceTolerance = 0.05f;

	#endregion

#region Fields (private)

	private IA_PlayerMovement m_inputActions = null;
	private Vector3 m_movementDirection = Vector3.zero;

	private readonly Collider[] m_groundCheckColliderCache = new Collider[5];
	private Vector3 m_groundCheckSphereOffset = Vector3.zero;

	private bool m_isGrounded = true;
	private bool m_isHoldingJumpInput = false;

	#endregion


	private void Awake()
	{
		InitializeInputs();
		InitializeGroundCheck();
	}

	private void InitializeInputs()
	{
		m_inputActions = new IA_PlayerMovement();
		m_inputActions.Enable();

		m_inputActions.Movement.Movement.started += UpdateMovementDirection;
		m_inputActions.Movement.Movement.performed += UpdateMovementDirection;
		m_inputActions.Movement.Movement.canceled += UpdateMovementDirection;

		m_inputActions.Movement.Jump.started += Jump;
		m_inputActions.Movement.Jump.canceled += StopJump;
	}

	private void InitializeGroundCheck()
	{
		m_groundCheckSphereOffset = Vector3.up * (m_groundCheckSphereRadius - m_groundCheckDistanceTolerance);
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
		if (!m_isGrounded && !m_isHoldingJumpInput)
			CheckIfGrounded();

		if (m_isGrounded)
			StopJump();

		if (m_movementDirection != Vector3.zero)
			Move();

		LookAtMouse();
	}

	private void FixedUpdate()
	{
		if (m_isHoldingJumpInput)
			UpdateLongJump();
	}

	private void UpdateMovementDirection(CallbackContext input)
	{
		m_movementDirection = input.ReadValue<Vector2>().xzy();
	}

	private void CheckIfGrounded()
	{
		m_isGrounded = Physics.OverlapSphereNonAlloc(transform.position + m_groundCheckSphereOffset, m_groundCheckSphereRadius, m_groundCheckColliderCache, m_groundCheckLayerMask) > 0;
	}

	private void Jump(CallbackContext input)
	{
		if (!m_isGrounded)
			return;

		m_isGrounded = false;
		m_isHoldingJumpInput = true;

		m_rigidbody.velocity = m_rigidbody.velocity.x_z();
		m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
	}

	private void UpdateLongJump()
	{
		float jumpForce = m_rigidbody.velocity.y > 0.0f ? m_longJumpForceAscending : m_longJumpForceDescending;

		m_rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
	}

	private void StopJump(CallbackContext input = default)
	{
		m_isHoldingJumpInput = false;
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
