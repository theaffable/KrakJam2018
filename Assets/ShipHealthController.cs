using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthController : MonoBehaviour {

	[SerializeField]
	int _maxHealth = 5;

	int _health = 0;

	[SerializeField]
	HealthDisplayer _healthDisplayer;

	// Use this for initialization
	void Start () {
		_healthDisplayer.Init (_maxHealth);
	}

	public void Damage(){
		_health--;
		_healthDisplayer.HideHeart ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
			_healthDisplayer.HideHeart ();	
		if (Input.GetKeyDown (KeyCode.R))
			_healthDisplayer.Reset (_maxHealth);	
	}

}
