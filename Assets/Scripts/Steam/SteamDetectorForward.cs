using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorForward : SteamDetector{

	override protected void SteamActive(){
		_steamStatusController.ForwardActive(_id);
	}
}
