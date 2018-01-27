using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorUp : SteamDetector {

	override protected void SteamActive(){
		_steamStatusController.UpActive(_id);
	}
}
