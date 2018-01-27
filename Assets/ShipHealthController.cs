using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthController : MonoBehaviour {

	[SerializeField]
	int _maxHealth = 5;

	int _health = 0;

	[SerializeField]
	HealthDisplayer[] _healthDisplayer;

	// Use this for initialization
	void Start () {
		foreach (HealthDisplayer hd in _healthDisplayer) {
			hd.Init (_maxHealth);
		}
	}

	public void Damage(){
		_health--;
		foreach (HealthDisplayer hd in _healthDisplayer) {
			hd.HideHeart ();
		}
	}
}
