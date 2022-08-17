
using UnityEngine;


public abstract class CameraBehaviour<DescriptorType> : ICameraBehaviour
														where DescriptorType : CameraBehaviourDescriptor
{
#region Fields (protected)

	protected readonly GameCamera m_camera = null;

	protected readonly DescriptorType m_descriptor = null;

	#endregion


	public CameraBehaviour(DescriptorType descriptor, GameCamera camera)
	{
		m_descriptor = descriptor;
		m_camera = camera;
	}

	public virtual void Initialize()
	{

	}

	public virtual void UpdateBehaviour(BasePawn target)
	{

	}
}
