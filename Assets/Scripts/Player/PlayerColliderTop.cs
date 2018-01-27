using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderTop : PlayerCollider {

	override public void Hit(){
		_pipeController.TopHit();
	}
}
