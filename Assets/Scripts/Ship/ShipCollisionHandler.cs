using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCollisionHandler : MonoBehaviour {


	[SerializeField]
	ShipHealthController _shipHealthController;
	[SerializeField]
	Text _gameOverText;
	[SerializeField]
	ScoreController _scoreController;

	// Use this for initialization
	void Start () {
		_gameOverText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.CompareTag("Obstacle")) {
			_shipHealthController.Damage ();
			Destroy (col.gameObject);
		}
		if (col.CompareTag("Death")) {
			_gameOverText.gameObject.SetActive (true);
			_scoreController.Stop ();
		}
	}
}
