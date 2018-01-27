using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorDown : SteamDetector {

	override protected void SteamActive(){
		Debug.Log ("elo");
		_steamStatusController.DownActive();
	}
}
