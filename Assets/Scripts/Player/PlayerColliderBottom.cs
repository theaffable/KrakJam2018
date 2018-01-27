using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderBottom : PlayerCollider {

	override public void Hit(){
		_pipeController.BottomHit();
	}
}
