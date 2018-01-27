using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorShootTop : SteamDetector {

	override protected void SteamActive(){
		_steamStatusController.ShootTopActive();
	}
}
