using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorDown : SteamDetector {

	override protected void SteamActive(){
		_steamStatusController.DownActive(_id);
	}
}
