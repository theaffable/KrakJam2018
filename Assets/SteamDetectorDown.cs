using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorDown : SteamDetector {

	override void SteamActive(){
		_steamStatusController.DownActive();
	}
}
