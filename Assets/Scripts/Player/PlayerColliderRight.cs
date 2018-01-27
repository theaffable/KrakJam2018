using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderRight : PlayerCollider {

	override public void Hit(){
		_pipeController.RightHit();
	}
}
