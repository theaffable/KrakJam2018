using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float stickTol = 0.9f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    var AV = -Input.GetAxis ("Vertical");
		var AH = -Input.GetAxis ("Horizontal");

		//first make sure stick vals are higher than the tolerance
		if ((Mathf.Abs (AH) > stickTol || Mathf.Abs (AV) > stickTol)) {
			if ((Mathf.Abs (AH) + Mathf.Abs (AV)) > 1) {
				float angle = Mathf.Atan2 (AH, AV) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
			}
		}
	}
}
