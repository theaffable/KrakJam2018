using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderBottom : MonoBehaviour, IPlayerCollider {

	[SerializeField]
	private PipeController _pipeController;

	public void Hit(){
		_pipeController.BottomHit();
	}
}
