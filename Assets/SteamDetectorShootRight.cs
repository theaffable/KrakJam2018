using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorShootRight : SteamDetector {

	override protected void SteamActive(){
		_steamStatusController.ShootRightActive();
	}
}
