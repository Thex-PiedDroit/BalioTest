
using UnityEngine;


public class PlayerPawn : Character
{
#region Fields (serialized)



	#endregion

#region Fields (private)



	#endregion


	private void Start()
	{
		GameCamera.ActiveCamera.SetTarget(this);
	}
}
