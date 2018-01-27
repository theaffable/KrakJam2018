using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour {


	[SerializeField]
	ShipHealthController _shipHealthController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag("Obstacle")) {
			_shipHealthController.Damage ();
			Destroy (col.gameObject);
		}
		if (col.gameObject.CompareTag("Death")) {
			Debug.Log ("Statek zmarł");
			Destroy(gameObject);
		}
	}
}
