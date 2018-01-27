using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("PlayerCollider")) {
			col.gameObject.GetComponent<IPlayerCollider>().Hit();
		}
	}
}
