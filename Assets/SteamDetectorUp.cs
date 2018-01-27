using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorUp : SteamDetector {

	override void SteamActive(){
		_steamStatusController.UpActive();
	}
}
