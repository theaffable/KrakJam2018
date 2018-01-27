using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorShootLeft : SteamDetector {

	override protected void SteamActive(){
		_steamStatusController.ShootLeftActive();
	}
}
