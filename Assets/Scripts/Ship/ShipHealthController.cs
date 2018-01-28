using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthController : MonoBehaviour {

	[SerializeField]
	int _maxHealth = 5;

	int _health = 0;

	[SerializeField]
	HealthDisplayer _healthDisplayer;
	ShipCollisionHandler _sch;

	// Use this for initialization
	void Start () {
		_health = _maxHealth;
		_sch = GetComponent<ShipCollisionHandler> ();
		_healthDisplayer.Init (_maxHealth);
	}

	public void Damage(){
		_health--;
		_healthDisplayer.HideHeart ();
		if (_health <= 0) {
			_sch._gameOverText.gameObject.SetActive(true);
			gameObject.GetComponent<AudioSource>().clip = _sch.GameOverSound;
			gameObject.GetComponent<AudioSource>().Play();
			_sch._scoreController.Stop();
		}
	}
}
