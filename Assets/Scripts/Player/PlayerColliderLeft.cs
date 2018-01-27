using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderLeft : PlayerCollider {

	override public void Hit(){
		_pipeController.LeftHit();
	}
}
