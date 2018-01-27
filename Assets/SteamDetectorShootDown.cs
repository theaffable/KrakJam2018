using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorShootDown : SteamDetector {

	override protected void SteamActive(){
		_steamStatusController.ShootDownActive();
	}
}
