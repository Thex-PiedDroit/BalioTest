
using System;
using UnityEngine;


public static class CameraBehaviourFactory
{
	public static ICameraBehaviour CreateBehaviour(CameraBehaviourDescriptor behaviourDescriptor, GameCamera camera)
	{
		return Activator.CreateInstance(behaviourDescriptor.BehaviourType, new object[] { behaviourDescriptor, camera }) as ICameraBehaviour;
	}
}
