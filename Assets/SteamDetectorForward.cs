using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorForward : SteamDetector{

	override void SteamActive(){
		_steamStatusController.ForwardActive();
	}
}
