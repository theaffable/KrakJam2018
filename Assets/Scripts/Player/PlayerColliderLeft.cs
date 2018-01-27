using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderLeft : MonoBehaviour, IPlayerCollider {

	[SerializeField]
	private PipeController _pipeController;

	public void Hit(){
		_pipeController.LeftHit();
	}
}
