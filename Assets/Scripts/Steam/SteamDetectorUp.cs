﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamDetectorUp : SteamDetector {

	override protected void SteamActive(){
		_captainMock.CheckForPoints(new CaptainMock.Pipe(1, CaptainMock.PipeLocation.Left));
	}
}
