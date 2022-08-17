
using UnityEngine;


public class CB_IsometricStyle : CameraBehaviour<CBD_IsometricStyle>
{
#region Fields (serialized)



	#endregion

#region Fields (private)

	private const float SMOOTH_LERP_FUNCTION_POWER_VALUE = 5.0f;

	private Vector3 m_followVelocity = Vector3.zero;

	#endregion


	public CB_IsometricStyle(CBD_IsometricStyle descriptor, GameCamera camera) : base(descriptor, camera)
	{

	}

	public override void Initialize()
	{
		m_camera.transform.localRotation = Quaternion.Euler(m_descriptor.DefaultRotation);
	}

	public override void UpdateBehaviour(BasePawn target)
	{
		if (target != null)
			FollowTarget(target);
	}

	private void FollowTarget(BasePawn target)
	{
		Vector3 targetPosition = target.CameraTargetPosition;
		Vector3 relativeMousePosition = m_camera.GetMouseRelativePosition(targetPosition);

		float distanceBetweenMouseAndTarget = relativeMousePosition.magnitude;

		float lookupDistance = m_descriptor.LookupDistanceFromMouse * Mathf.Min(distanceBetweenMouseAndTarget, m_descriptor.MaxMouseDistanceForLookup);
		Vector3 lookupPosition = targetPosition + (relativeMousePosition.normalized * lookupDistance);

		float lookupDropOffProgress = Mathf.Min(distanceBetweenMouseAndTarget, m_descriptor.MaxMouseDistanceForLookup) / m_descriptor.MaxMouseDistanceForLookup;
		float lerpValue = Mathf.Max(0.0f, Mathf.Cos(Mathf.Pow(lookupDropOffProgress, SMOOTH_LERP_FUNCTION_POWER_VALUE) * (Mathf.PI * 0.5f)));
		float smoothFactorValue = Mathf.Lerp(m_descriptor.SmoothFollowFactor.Max, m_descriptor.SmoothFollowFactor.Min, lerpValue);

		m_camera.transform.position = Vector3.SmoothDamp(m_camera.transform.position, lookupPosition + m_descriptor.OffsetFromTarget, ref m_followVelocity, smoothFactorValue);
	}
}
