using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteamDetector : MonoBehaviour {

	protected SteamStatusController _steamStatusController;
	int _particleCounter=0;

	// Use this for initialization
	void Start () {
		_steamStatusController = FindObjectOfType<SteamStatusController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other) {
		if (_particleCounter >= 100) {
			_particleCounter = 0;
			SteamActive();
		}
		else
			_particleCounter++;
	}

	protected abstract void SteamActive();
}
