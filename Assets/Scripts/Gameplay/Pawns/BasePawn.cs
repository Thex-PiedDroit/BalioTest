
using UnityEngine;


public class BasePawn : MonoBehaviour
{
#region Fields (serialized)

	[SerializeField]
	private Vector3 m_cameraTargetPoint = Vector3.up;
	public Vector3 CameraTargetPosition => transform.position + m_cameraTargetPoint;

	#endregion

#region Fields (private)

	private const string CAMERA_TARGET_POINT_GIZMO_ICON = "scenevis_visible_hover@2x";

	#endregion


	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawIcon(CameraTargetPosition, CAMERA_TARGET_POINT_GIZMO_ICON, true, Color.black);
	}
}
